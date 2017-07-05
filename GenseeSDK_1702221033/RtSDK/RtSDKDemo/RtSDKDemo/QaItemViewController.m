//
//  QaItemViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 4/6/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "QaItemViewController.h"
#import <RtSDK/RtSDK.h>
#import "MBProgressHUD.h"
#import "GHInputToolView.h"

@interface QaItemViewController ()<GSBroadcastRoomDelegate, GSBroadcastQaDelegate, UITableViewDataSource, UITableViewDelegate, GHToolViewDelegate>

@property (strong, nonatomic)GSBroadcastManager *broadcastManager;
@property (strong, nonatomic)MBProgressHUD *progressHUD;
@property (strong, nonatomic)UITableView *tableView;
@property (strong, nonatomic)NSMutableDictionary *questionsDic;
@property (strong, nonatomic)NSMutableArray *questionArray;
@property (strong, nonatomic)GHInputToolView *inputToolView;
@property (assign, nonatomic)long long myUserID;

@end

@implementation QaItemViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    _questionsDic = [NSMutableDictionary dictionary];
    _questionArray = [NSMutableArray array];
    
    self.progressHUD = [[MBProgressHUD alloc]initWithView:self.navigationController.view];
    [self.navigationController.view addSubview:self.progressHUD];
    self.progressHUD.labelText =  NSLocalizedString(@"BroadcastConnecting",  @"直播连接提示");

    [self.progressHUD show:YES];
    
    // 设置tableView
    [self setUpTableView];
    
    self.inputToolView = [[GHInputToolView alloc]initWithParentFrame:self.view.frame emojiPlistFileName:nil inBundle:nil];
    [self.inputToolView.emojiButton setHidden:YES];
    [self.view addSubview:self.inputToolView];
    self.inputToolView.delegate = self;
    
    // 初始化直播管理类
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

- (void)setUpTableView
{
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    if (version < 7.0) {
        // iOS 6 code
        self.tableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height -52 - 44)];
    }
    else if (version < 8.0)
    {
        // iOS 7 code
        self.tableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 64, self.view.frame.size.width, self.view.frame.size.height - 64 -52)];
    }
    else
    {
        // iOS8 code
        self.tableView = [[UITableView alloc]initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height - 52)];
    }
    
    [self setExtraCellLineHidden:self.tableView];
    self.tableView.dataSource = self;
    self.tableView.delegate = self;
    [self.view addSubview:self.tableView];
    
    UITapGestureRecognizer *ges = [[UITapGestureRecognizer alloc]initWithTarget:self action:@selector(handleTableViewTap:)];
    ges.numberOfTouchesRequired = 1;
    [self.tableView addGestureRecognizer:ges];
    
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
    self.broadcastManager.qaDelegate = self;
    
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
#pragma mark GHToolViewDelegate
- (void)sendMessage:(NSString *)content
{
        if (!content || [[content stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]] isEqualToString:@""]) {
            UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"QuestionContentEmpty", @"提问的内容不能为空") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK", @"确认") otherButtonTitles:nil, nil];
            [alertView show];
            return;
        }
    
        if ([self.broadcastManager askQuestion:content]) {
            
            self.inputToolView.inputTextView.text = @"";
        }
        else
        {
            UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"SendingQuestionFailed", @"发送问题失败") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK", @"确认") otherButtonTitles:nil, nil];
            [alertView show];
            
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
#pragma mark GSBroadcastQaDelegate

// 问答模块连接代理
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didReceiveQaModuleInitResult:(BOOL)result
{
    
}

// 问答设置状态改变代理
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager didSetQaEnabled:(BOOL)enabled QuestionAutoDispatch:(BOOL)autoDispatch QuestionAutoPublish:(BOOL)autoPublish
{
    
}

// 问题的状态改变代理，包括收到一个新问题，问题被发布，取消发布等
- (void)broadcastManager:(GSBroadcastManager*)broadcastManager question:(GSQuestion*)question updatesOnStatus:(GSQaStatus)status
{
    switch (status) {
        case GSQaStatusNewAnswer:
        {
            if ([self.questionArray containsObject:question.questionID]) {
                
                [self.questionsDic setObject:question forKey:question.questionID];
                NSUInteger index = [_questionArray indexOfObject:question.questionID];
                
                NSIndexPath *indexPath = [NSIndexPath indexPathForRow:question.answers.count - 1 inSection:index];
                NSMutableArray *indexPaths = [NSMutableArray array];
                [indexPaths addObject:indexPath];
                [self.tableView insertRowsAtIndexPaths:indexPaths withRowAnimation:UITableViewRowAnimationFade];

            }
            
        }

            break;
            
        case GSQaStatusQuestionPublish:
        {
            [self.questionsDic setObject:question forKey:question.questionID];
            
            if (![_questionArray containsObject:question.questionID]) {
                
                [_questionArray addObject:question.questionID];
                
                NSIndexSet *indexSet = [NSIndexSet indexSetWithIndex:self.questionArray.count - 1];
                NSLog(@"iOSDemo: insertSection: %d", self.questionArray.count - 1);
                [self.tableView insertSections:indexSet withRowAnimation:UITableViewRowAnimationFade];
                
            }
            
        }
            break;
            
            
        case GSQaStatusQuestionCancelPublish:
        {
            
            [self.questionsDic removeObjectForKey:question.questionID];
            
            if ([self.questionArray containsObject:question.questionID]) {
                
                NSUInteger index = [self.questionArray indexOfObject:question.questionID];
                
                [self.questionArray removeObjectAtIndex:index];
                
                NSIndexSet *indexSet = [NSIndexSet indexSetWithIndex:index];
                
                [self.tableView deleteSections:indexSet withRowAnimation:UITableViewRowAnimationFade];
                
            }
        }
            
            break;
            
            case GSQaStatusNewQuestion:
        {
            // 如果是自己提的问题，可以看到，如果是别人提的问题，要发布了才能看到
            if (question.ownerID == _myUserID) {
                
                [self.questionsDic setObject:question forKey:question.questionID];
                
                if (![_questionArray containsObject:question.questionID]) {
                    
                    [_questionArray addObject:question.questionID];
                    
                    NSIndexSet *indexSet = [NSIndexSet indexSetWithIndex:self.questionArray.count - 1];
                    NSLog(@"iOSDemo: insertSection: %d", self.questionArray.count - 1);
                    [self.tableView insertSections:indexSet withRowAnimation:UITableViewRowAnimationFade];
                    
                }
            }
        }
            break;
            
            
            
            
        default:
            break;
    }
}

#pragma mark - 
#pragma mark TableViewDelegate

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{

    return ((GSQuestion*)[_questionsDic objectForKey:_questionArray[section]]).answers.count;
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return _questionArray.count;
}

- (UITableViewCell*)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"cell"];
    if (!cell) {
        cell = [[UITableViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"cell"];
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
    }
    NSArray *answers = ((GSQuestion*)[_questionsDic objectForKey:_questionArray[indexPath.section]]).answers;
    cell.textLabel.text = [NSString stringWithFormat:@" A: %@", ((GSAnswer*)answers[indexPath.row]).answerContent];
    
    NSLog(@"iOSDemo: section: %d row: %d  answer: %@", indexPath.section, indexPath.row, ((GSAnswer*)answers[indexPath.row]).answerContent);
    
    return cell;
}

- (UIView*)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    UIView *view = [[UIView alloc]initWithFrame:CGRectMake(0, 0, self.tableView.bounds.size.width, 50)];
    UILabel *label = [[UILabel alloc]initWithFrame:view.bounds];
    
   
    label.text = [NSString stringWithFormat:@"  Q: %@", ((GSQuestion*)[_questionsDic objectForKey:_questionArray[section]]).questionContent];
    [view addSubview:label];
    
    NSLog(@"iOSDemo: section: %d", section);
    
    return view;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 50;
}

#pragma mark -
#pragma mark System Default Code

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
