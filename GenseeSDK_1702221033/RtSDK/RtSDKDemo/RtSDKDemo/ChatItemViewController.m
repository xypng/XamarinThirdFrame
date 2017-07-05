//
//  ChatItemViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 4/6/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "ChatItemViewController.h"
#import <RtSDK/RtSDK.h>
#import "MBProgressHUD.h"
#import "GHInputToolView.h"
#import "ChatCell.h"
#import "ChatMessageInfo.h"

@interface ChatItemViewController ()<GSBroadcastRoomDelegate, GSBroadcastChatDelegate, UITableViewDataSource, UITableViewDelegate, GHToolViewDelegate>

@property (nonatomic, strong)GSBroadcastManager *broadcastManager;

@property (nonatomic, strong)MBProgressHUD *progressHUD;

@property (nonatomic, strong)UITableView *chatTableView;

@property (nonatomic, strong)NSMutableArray *chatMessage;

@property (nonatomic, strong)GHInputToolView *inputToolView;

@property (nonatomic, assign)long long myUserID;

@property (nonatomic, strong)NSDictionary *key2fileDic;

@property (nonatomic, strong)NSDictionary *text2keyDic;

@end

@implementation ChatItemViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    self.chatMessage = [NSMutableArray array];
    
    [self setUpChatTableView];
    
    NSBundle *resourceBundle = [NSBundle bundleWithPath:[[NSBundle mainBundle] pathForResource:@"RtSDK" ofType:@"bundle"]];
    _key2fileDic = [NSDictionary dictionaryWithContentsOfFile:[resourceBundle pathForResource:@"key2file" ofType:@"plist"]];
    _text2keyDic = [NSDictionary dictionaryWithContentsOfFile:[resourceBundle pathForResource:@"text2key" ofType:@"plist"]];


    self.inputToolView = [[GHInputToolView alloc]initWithParentFrame:self.view.frame emojiPlistFileName:@"text2file" inBundle:resourceBundle];
    [self.view addSubview:self.inputToolView];
    self.inputToolView.delegate = self;
    
    self.progressHUD = [[MBProgressHUD alloc]initWithView:self.navigationController.view];
    [self.navigationController.view addSubview:self.progressHUD];
    self.progressHUD.labelText =  NSLocalizedString(@"BroadcastConnecting",  @"直播连接提示");
    [self.progressHUD show:YES];
    
    NSLog(@"%f, %f", self.view.frame.origin.x, self.view.frame.origin.y);
    
    [self initBroadCastManager];
    UIBarButtonItem *left = [[UIBarButtonItem alloc]initWithTitle:@"back" style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = left;
    
}

- (void)back:(id)sender
{
    [self.progressHUD show:YES];
    self.progressHUD.labelText = @"Leaving...";
    [self.broadcastManager leaveAndShouldTerminateBroadcast:NO];
}

- (void)setUpChatTableView
{
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    if (version < 7.0) {
      // iOS 6 code
        self.chatTableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height - 52 - 44)];
    }
    else if (version < 8.0)
    {
        // iOS 7 code
        self.chatTableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 64, self.view.frame.size.width, self.view.frame.size.height - 64 - 52)];
    }
    else
    {
        // iOS8 code
        self.chatTableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height - 52)];
    }
    
    [self setExtraCellLineHidden:self.chatTableView];
    self.chatTableView.dataSource = self;
    self.chatTableView.delegate = self;
    [self.view addSubview:self.chatTableView];
    
    UITapGestureRecognizer *ges = [[UITapGestureRecognizer alloc]initWithTarget:self action:@selector(handleTableViewTap:)];
    ges.numberOfTouchesRequired = 1;
    [self.chatTableView addGestureRecognizer:ges];

}

-(void)setExtraCellLineHidden: (UITableView *)tableView
{
    UIView *view = [UIView new];
    view.backgroundColor = [UIColor clearColor];
    [tableView setTableFooterView:view];
}

- (void)initBroadCastManager
{
    self.broadcastManager = [GSBroadcastManager sharedBroadcastManager];
    self.broadcastManager.broadcastRoomDelegate = self;
    self.broadcastManager.chatDelegate = self;
    
    if (![_broadcastManager connectBroadcastWithConnectInfo:self.connectInfo]) {
        
        [self.progressHUD show:NO];
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"WrongConnectInfo", @"参数不正确") delegate:self cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alertView show];
        
    }
    
}

#pragma mark -
#pragma mark Actions

- (void)handleTableViewTap:(UITapGestureRecognizer*)ges
{
    [_inputToolView endEditting];
}

#pragma mark -
#pragma mark GHInputToolViewDelegate

- (void)sendMessage:(NSString *)content
{
    
    
    [_broadcastManager setUser:1000000001 chatEnabled:NO];
    
    if (!content || [[content stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]]isEqualToString:@""])
    {
        UIAlertView *alert = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"EmptyChat", @"消息为空") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alert show];
        return;
    }
    
    
    
    GSChatMessage *message = [GSChatMessage new];
    message.text = [NSString stringWithFormat:@"<span>%@</span>", content];
    message.richText = [self chatString:content];
    
    
    // 发送公共消息
    if ([_broadcastManager sendMessageToPublic:message]) {
        
        
        [self receiveChatMessage:message from:nil messageType:ChatMessageTypeFromMe];
        
    }
    else
    {
        // 发送失败
    }

}

#pragma mark -
#pragma mark GSBroadcastManagerDelegate

// 直播初始化代理
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveBroadcastConnectResult:(GSBroadcastConnectResult)result
{
    switch (result) {
        case GSBroadcastConnectResultSuccess:
            
            // 直播初始化成功，加入直播
            if (![self.broadcastManager join]) {
                
                [self.progressHUD hide:YES];
                UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:  NSLocalizedString(@"BroadcastConnectionError",  @"直播连接失败提示") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK",  @"确认") otherButtonTitles:nil, nil];
                [alertView show];
                
                
            }
            
            break;
            
        case GSBroadcastConnectResultInitFailed:
            
        case GSBroadcastConnectResultJoinCastPasswordError:
            
        case GSBroadcastConnectResultWebcastIDInvalid:
            
        case GSBroadcastConnectResultRoleOrDomainError:
            
        case GSBroadcastConnectResultLoginFailed:
            
        case GSBroadcastConnectResultNetworkError:
            
        case  GSBroadcastConnectResultThirdTokenError:
            
        case GSBroadcastConnectResultWebcastIDNotFound:
        {
            [self.progressHUD hide:YES];
            UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:  NSLocalizedString(@"BroadcastConnectionError",  @"直播连接失败提示") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK",  @"确认") otherButtonTitles:nil, nil];
            [alertView show];
        }
            break;
            
            
        default:
            break;
    }
}

/*
 直播连接代理
 rebooted为YES，表示这次连接行为的产生是由于根服务器重启而导致的重连
 */
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveBroadcastJoinResult:(GSBroadcastJoinResult)joinResult selfUserID:(long long)userID rootSeverRebooted:(BOOL)rebooted;
{
    [self.progressHUD hide:YES];
    
    // 服务器重启导致重连
    if (rebooted) {
        // 相应处理
        
    }
}

// 断线重连
- (void)broadcastManagerWillStartRoomReconnect:(GSBroadcastManager*)manager
{
    [self.progressHUD show:YES];
    self.progressHUD.labelText = NSLocalizedString(@"Reconnect", @"正在重连");
    
}

- (void)broadcastManager:(GSBroadcastManager*)manager didSelfLeaveBroadcastFor:(GSBroadcastLeaveReason)leaveReason
{
    [self.broadcastManager invalidate];
    [self.progressHUD hide:YES];
    [self.navigationController popViewControllerAnimated:YES];
}


#pragma mark -
#pragma mark GSBroadcastChatDelegate

// 聊天模块连接代理
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didReceiveChatModuleInitResult:(BOOL)result
{
    
}

// 收到私人聊天代理, 只有自己能看到。
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didReceivePrivateMessage:(GSChatMessage*)msg fromUser:(GSUserInfo*)user
{
    [self receiveChatMessage:msg from:user messageType:ChatMessageTypePrivate];
}

// 收到公共聊天代理，所有人都能看到
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didReceivePublicMessage:(GSChatMessage*)msg fromUser:(GSUserInfo*)user
{
    [self receiveChatMessage:msg from:user messageType:ChatMessageTypePublic];
}

// 收到嘉宾聊天代理
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didReceivePanelistMessage:(GSChatMessage*)msg fromUser:(GSUserInfo*)user
{
    [self receiveChatMessage:msg from:user messageType:ChatMessageTypePanelist];
}

// 针对个人禁止或允许聊天/问答 状态改变代理，如果想设置整个房间禁止聊天，请用其他的代理
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didSetChattingEnabled:(BOOL)enabled
{
    
}

#pragma mark -
#pragma mark UITableViewDelegate

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.chatMessage.count;
}

- (UITableViewCell*)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *identifier = @"cell";
    
    ChatCell *chatCell = [tableView dequeueReusableCellWithIdentifier:identifier];
    if (!chatCell) {
        chatCell = [[ChatCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:identifier];
        chatCell.key2fileDic = _key2fileDic;
        NSLog(@"new");
    }
    else
    {
        NSLog(@"reuse");
    }
    ChatMessageInfo *messageInfo = self.chatMessage[indexPath.row];
    [chatCell setContent:messageInfo];
    
    return chatCell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *text = ((ChatMessageInfo*)_chatMessage[indexPath.row]).message.richText;
    int height = [self heightOfText:[self transfromString2:text] width:self.view.frame.size.width - 20 fontSize:12.f];
    return height + 40 + 25;
}

#pragma mark -
#pragma mark Utilities

- (CGFloat)heightOfText:(NSString*)content width:(CGFloat)width fontSize:(CGFloat)fontSize
{
    CGSize constraint = CGSizeMake(width, CGFLOAT_MAX);
    CGSize  size = [content sizeWithFont:[UIFont systemFontOfSize:fontSize] constrainedToSize:constraint lineBreakMode:NSLineBreakByCharWrapping];
    return MAX(size.height, 20);
}

- (NSString*)transfromString2:(NSString*)originalString
{
    //匹配表情，将表情转化为html格式
    NSString *text = originalString;
    //【伤心】
    //NSString *regex_emoji = @"\\[[a-zA-Z0-9\\u4e00-\\u9fa5]+\\]";
    
    NSRegularExpression* preRegex = [[NSRegularExpression alloc]
                                     initWithPattern:@"<IMG.+?src=\"(.*?)\".*?>"
                                     options:NSRegularExpressionCaseInsensitive|NSRegularExpressionDotMatchesLineSeparators
                                     error:nil]; //2
    NSArray* matches = [preRegex matchesInString:text options:0
                                           range:NSMakeRange(0, [text length])];
    int offset = 0;
    
    for (NSTextCheckingResult *match in matches) {
        //NSRange srcMatchRange = [match range];
        NSRange imgMatchRange = [match rangeAtIndex:0];
        imgMatchRange.location += offset;
        
        NSString *imgMatchString = [text substringWithRange:imgMatchRange];
        
        
        NSRange srcMatchRange = [match rangeAtIndex:1];
        srcMatchRange.location += offset;
        
        NSString *srcMatchString = [text substringWithRange:srcMatchRange];
        
        NSString *i_transCharacter = [self.key2fileDic objectForKey:srcMatchString];
        if (i_transCharacter) {
            NSString *imageHtml =@"表情表情表情";//表情占位，用于计算文本长度
            text = [text stringByReplacingCharactersInRange:NSMakeRange(imgMatchRange.location, [imgMatchString length]) withString:imageHtml];
            offset += (imageHtml.length - imgMatchString.length);
        }
        
    }
    
    //返回转义后的字符串
    return text;
    
}


- (void)receiveChatMessage:(GSChatMessage*)msg from:(GSUserInfo*)user messageType:(ChatMessageType)messageType
{

    ChatMessageInfo *messageInfo = [ChatMessageInfo new];
    
    if (messageType == ChatMessageTypeFromMe) {
        messageInfo.senderName = NSLocalizedString(@"Me", @"我");
        messageInfo.senderID = _myUserID;
    }
    else if (messageType == ChatMessageTypeSystem)
    {
        messageInfo.senderName = NSLocalizedString(@"System", @"系统消息");
    }
    else
    {
        messageInfo.senderID = user.userID;
        messageInfo.senderName = user.userName;
    }

    NSDateFormatter *formater = [[ NSDateFormatter alloc] init];
    NSDate *curDate = [NSDate date];//获取当前日期
    [formater setDateFormat:@"HH:mm:ss"];//这里去掉 具体时间 保留日期
    NSString *curTime = [formater stringFromDate:curDate];
    messageInfo.receiveTime = curTime;
    
    messageInfo.messageType = messageType;
    
    messageInfo.message = msg;
    
    [self.chatMessage addObject:messageInfo];
    
    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:self.chatMessage.count - 1 inSection:0];
    NSMutableArray *indexPaths = [NSMutableArray array];
    [indexPaths addObject:indexPath];
    [self.chatTableView insertRowsAtIndexPaths:indexPaths withRowAnimation:UITableViewRowAnimationFade];
}


- (NSString*)chatString:(NSString*)originalStr
{
    
    NSArray *textTailArray =  [[NSArray alloc]initWithObjects: @"【太快了】", @"【太慢了】", @"【赞同】", @"【反对】", @"【鼓掌】", @"【值得思考】",nil];
    
    NSRegularExpression* preRegex = [[NSRegularExpression alloc]
                                     initWithPattern:@"【([\u4E00-\u9FFF]*?)】"
                                     options:NSRegularExpressionCaseInsensitive|NSRegularExpressionDotMatchesLineSeparators
                                     error:nil]; //2
    NSArray* matches = [preRegex matchesInString:originalStr options:0
                                           range:NSMakeRange(0, [originalStr length])];
    
    int offset = 0;
    
    for (NSTextCheckingResult *match in matches) {
        //NSRange srcMatchRange = [match range];
        NSRange emotionRange = [match rangeAtIndex:0];
        emotionRange.location += offset;
        
        NSString *emotionString = [originalStr substringWithRange:emotionRange];
        
        NSString *i_transCharacter = [_text2keyDic objectForKey:emotionString];
        if (i_transCharacter) {
            NSString *imageHtml = nil;
            if([textTailArray containsObject:emotionString])
            {
                imageHtml = [NSString stringWithFormat:@"<IMG src=\"%@\" custom=\"false\">%@", i_transCharacter, emotionString];
            }
            else
            {
                imageHtml = [NSString stringWithFormat:@"<IMG src=\"%@\" custom=\"false\">", i_transCharacter];
            }
            originalStr = [originalStr stringByReplacingCharactersInRange:NSMakeRange(emotionRange.location, [emotionString length]) withString:imageHtml];
            offset += (imageHtml.length - emotionString.length);
            
        }
        
    }
    
    
    NSMutableString *richStr = [[NSMutableString alloc]init];
    [richStr appendString:@"<SPAN style=\"FONT-SIZE: 10pt; FONT-WEIGHT: normal; COLOR: #000000; FONT-STYLE: normal\">"];
    [richStr appendString:originalStr];
    [richStr appendString:@"</SPAN>"];
    
    return richStr;

}

#pragma mark -
#pragma mark - System Default Code

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (void)dealloc
{
    // 退出直播，但不结束直播, 若参数为YES,直播将同时结束
    [self.broadcastManager leaveAndShouldTerminateBroadcast:NO];
    // 释放资源
    [self.broadcastManager invalidate];
}

@end
