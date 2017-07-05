//
//  LoginViewController.m
//  VodSDKDemo
//
//  Created by gs_mac_wjj on 15/9/21.
//  Copyright © 2015年 Gensee. All rights reserved.
//

#import "ViewController.h"
#import "NSUserDefaults+UserDefaults.h"
#import "LoginViewController.h"
#import "DownLoadViewController.h"
#import "MBProgressHUD.h"


@interface LoginViewController ()<UITextFieldDelegate,VodDownLoadDelegate>
{
    BOOL islivePlay;
    MBProgressHUD *progressHUD;
}

@property (weak, nonatomic) IBOutlet UITextField *domain;
@property (weak, nonatomic) IBOutlet UITextField *serviceType;
@property (weak, nonatomic) IBOutlet UITextField *number;
@property (weak, nonatomic) IBOutlet UITextField *vodPassword;
@property (weak, nonatomic) IBOutlet UIButton *downloadBtn;
@property (weak, nonatomic) IBOutlet UIButton *livePlayBtn;
@property (weak, nonatomic) IBOutlet UITextField *thirdTokenTextField;


@property (nonatomic, strong) VodDownLoader *voddownloader;
@property (nonatomic, strong) ViewController *liveViewController;
@property (nonatomic, strong) DownLoadViewController *downloadViewController;

@end

@implementation LoginViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
//    获取上次输入的数据
    _domain.text = [[NSUserDefaults standardUserDefaults] getDomain];
    _serviceType.text = [[NSUserDefaults standardUserDefaults] getServiceType];
    _number.text = [[NSUserDefaults standardUserDefaults] getNumber];
    _vodPassword.text = [[NSUserDefaults standardUserDefaults] getVodPassword];
    
    _domain.delegate = self;
    _serviceType.delegate = self;
    _number.delegate = self;
    _vodPassword.delegate = self;
    _thirdTokenTextField.delegate = self;

    [_downloadBtn addTarget:self action:@selector(doDownload) forControlEvents:UIControlEventTouchUpInside];
    [_livePlayBtn addTarget:self action:@selector(doLivePlay) forControlEvents:UIControlEventTouchUpInside];
    
    if (!_voddownloader) {
        _voddownloader = [[VodDownLoader alloc]init];
    }
    _voddownloader.delegate = self;

}

/**
 *下载
 */
- (void)doDownload
{
    islivePlay = NO;
//    存入输入的数据
    [[NSUserDefaults standardUserDefaults] setDomain:_domain.text];
    [[NSUserDefaults standardUserDefaults] setServiceType:_serviceType.text];
    [[NSUserDefaults standardUserDefaults] setNumber:_number.text];
    [[NSUserDefaults standardUserDefaults] setVodPassword:_vodPassword.text];
    [[NSUserDefaults standardUserDefaults] synchronize];

    
    [_voddownloader addItem:_domain.text number:_number.text loginName:nil vodPassword:_vodPassword.text loginPassword:nil downFlag:0 serType:_serviceType.text oldVersion:NO
                     kToken:_thirdTokenTextField.text customUserID:0];
////
//
    
//    [self.voddownloader addItem:@"weiyiceshi.gensee.com" number:@"62239998" loginName:nil vodPassword:@"333333" loginPassword:nil downFlag:1 serType:@"webcast" oldVersion:NO
//                         kToken:nil customUserID:0];
    
    NSArray *array =  [[VodManage shareManage]getListOfUnDownloadedItem];
    
    for (downItem *item in array) {
        NSLog(@"item size: %@", item.fileSize);
    }
    

//    [_voddownloader addItem:@"sunlands.gensee.com" number:@"" loginName:@"" vodPassword:@"999999" loginPassword:@"" vodid:@"22982b277a3b4cce91e3cba484e8f17e" downFlag:1 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
    
//    [_voddownloader addItem:@"svmuu.gensee.com" number:nil loginName:nil vodPassword:nil loginPassword:nil vodid:@"efd71d9424ad48f2a71c1be5d7e12d73" downFlag:0 serType:@"webcast" oldVersion:NO kToken:nil];

    UIStoryboard *board = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
    _downloadViewController = [board instantiateViewControllerWithIdentifier:@"downloader"];

//    [MBProgressHUD showHUDAddedTo:self.view animated:YES];
}


//URLEncode
- (NSString*)encodeString:(NSString*)unencodedString{
    
    // CharactersToBeEscaped = @":/?&=;+!@#$()~',*";
    // CharactersToLeaveUnescaped = @"[].";
    
    NSString *encodedString = (NSString *)
    CFBridgingRelease(CFURLCreateStringByAddingPercentEscapes(kCFAllocatorDefault,
                                                              (CFStringRef)unencodedString,
                                                              NULL,
                                                              (CFStringRef)@"!*'();:@&=+$,/?%#[]",
                                                              kCFStringEncodingUTF8));
    
    return encodedString;
}

/**
 *在线播放
 */
- (void)doLivePlay
{
    islivePlay = YES;
    //    存入输入的数据
    [[NSUserDefaults standardUserDefaults] setDomain:_domain.text];
    [[NSUserDefaults standardUserDefaults] setServiceType:_serviceType.text];
    [[NSUserDefaults standardUserDefaults] setNumber:_number.text];
    [[NSUserDefaults standardUserDefaults] setVodPassword:_vodPassword.text];
    [[NSUserDefaults standardUserDefaults] synchronize];
    
    [self.voddownloader addItem:_domain.text number:_number.text loginName:nil vodPassword:_vodPassword.text loginPassword:nil downFlag:0 serType:_serviceType.text oldVersion:NO kToken:_thirdTokenTextField.text customUserID:0];

//    [_voddownloader addItem:@"192.168.1.225" number:nil loginName:nil vodPassword:@"" loginPassword:nil vodid:@"421740136c02436c8e0b60bf3210186c" downFlag:1 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
//////
    
//    [_voddownloader addItem:@"exam8.gensee.com" number:@"68745514" loginName:nil vodPassword:@"" loginPassword:nil vodid:@"" downFlag:1 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
    
//    [_voddownloader addItem:@"htexam.gensee.com" number:@"24823247" loginName:nil vodPassword:@"" loginPassword:nil downFlag:0 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
//    
//      [_voddownloader addItem:@"weiyiceshi.gensee.com" number:@"62239998" loginName:nil vodPassword:@"333333" loginPassword:nil downFlag:0 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
//
//    [_voddownloader addItem:@"htexam.gensee.com" number:nil loginName:nil vodPassword:@"shijiang123" loginPassword:nil vodid:@"c45ddeca0a5e45aab5dd448d04d5e3eb" downFlag:0 serType:@"webcast" oldVersion:YES kToken:nil customUserID:0];

    
//    VodParam *param = [VodParam new];
//    param.domain = @"192.168.1.225";
//    param.number = @"61511818";
//    param.vodID = @"72fc41a2e31042d9b0a0bf44d988edd9";
//    param.serviceType = @"webcast";
//    param.vodPassword = @"";
//
//    
//    
//    param.nickName = @"住在123abc@";
//    
//    param.oldVersion = NO;
//    
//    
//    [_voddownloader addItem:param];
//    
//    [_voddownloader addItem:@"91open.gensee.com" number:@"10299099" loginName:nil vodPassword:@"" loginPassword:nil vodid:@"" downFlag:1 serType:@"training" oldVersion:NO kToken:nil customUserID:0];
//
//    [self.voddownloader addItem:@"cf8.gensee.com" number:@"61529694" loginName:@"" vodPassword:@"" loginPassword:@"" vodid:@""  downFlag:0 serType:@"webcast" oldVersion:NO kToken:nil customUserID:0];
//
//     vodDownLoader.addItem("sunlands.gensee.com", number: "", loginName: "", vodPassword: "999999", loginPassword: "", vodid: self.genseeVodId , downFlag: 0, serType: serType , oldVersion: true, kToken: "", customUserID: customUserID )
//
    UIStoryboard *board = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
    _liveViewController = [board instantiateViewControllerWithIdentifier:@"player"];
    
    [MBProgressHUD showHUDAddedTo:self.view animated:YES];
}




#pragma mark - VodDownLoadDelegate
//添加item的回调方法
- (void)onAddItemResult:(RESULT_TYPE)resultType voditem:(downItem *)item
{
    if (resultType == RESULT_SUCCESS) {
        

//        vodId = item.strDownloadID;
        if (islivePlay) {
            [_liveViewController setItem:item];
            [_liveViewController setIsLivePlay:YES];
            [self.navigationController pushViewController:_liveViewController animated:YES];
        } else {
            [_downloadViewController setDomain:_domain.text];
            [_downloadViewController setNumber:_number.text];
            [_downloadViewController setVodPassword:_vodPassword.text];
            [_downloadViewController setSeviceType:_serviceType.text];
            
            [self.navigationController pushViewController:_downloadViewController animated:YES];
        }

//        [MBProgressHUD hideHUDForView:self.view animated:YES];
    }else if (resultType == RESULT_ROOM_NUMBER_UNEXIST){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"点播间不存在" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_FAILED_NET_REQUIRED){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"网络请求失败" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_FAIL_LOGIN){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"用户名或密码错误" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_NOT_EXSITE){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"该点播的编号的点播不存在" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_INVALID_ADDRESS){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"无效地址" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_UNSURPORT_MOBILE){
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"不支持移动设备" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
        [alertView show];
    }else if (resultType == RESULT_FAIL_TOKEN){
    UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"口令错误" ,@"") delegate:nil cancelButtonTitle:NSLocalizedString(@"知道了",@"") otherButtonTitles:nil, nil];
    [alertView show];
}
    [MBProgressHUD hideHUDForView:self.view animated:YES];
//    [MBProgressHUD hideAllHUDsForView:self.view animated:YES];
}

#pragma mark - UITextFieldDelgate
/**
 *处理键盘遮盖
 */
- (void)textFieldDidBeginEditing:(UITextField *)textField
{
    CGRect frame = textField.frame;
    int offset = frame.origin.y + 32 - (self.view.frame.size.height - 216.0);
    
    if(offset > 0) {
        NSTimeInterval animationDuration = 0.30f;
        [UIView beginAnimations:@"ResizeForKeyboard" context:nil];
        [UIView setAnimationDuration:animationDuration];
        
        //将视图的Y坐标向上移动offset个单位，以使下面腾出地方用于软键盘的显示
        self.view.frame = CGRectMake(0.0f, -offset, self.view.frame.size.width, self.view.frame.size.height);
        [UIView commitAnimations];
    }
}

- (void)textFieldDidEndEditing:(UITextField *)textField
{
    int offset = self.view.frame.origin.y;
    if (offset < 0) {
        NSTimeInterval animationDuration = 0.30f;
        [UIView beginAnimations:@"ResizeforKeyboard" context:nil];
        [UIView setAnimationDuration:animationDuration];
        
        //将视图的Y坐标向下移动offset个单位，以使下面腾出地方用于软键盘的显示
        self.view.frame = CGRectMake(0.0f, 0.0, self.view.frame.size.width, self.view.frame.size.height);
        [UIView commitAnimations];
    }
}

#pragma mark Actions
- (void)touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event
{
    [self.view endEditing:YES];
}

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

@end
