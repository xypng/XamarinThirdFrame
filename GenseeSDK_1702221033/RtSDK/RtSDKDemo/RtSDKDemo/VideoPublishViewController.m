//
//  VideoPublishViewController.m
//  iOSDemo
//
//  Created by colin on 15/10/30.
//  Copyright © 2015年 gensee. All rights reserved.
//

#import "VideoPublishViewController.h"
#import <RtSDK/RtSDK.h>
#import "MBProgressHUD.h"
#import <AVFoundation/AVFoundation.h>
#import "AppDelegate.h"

@interface VideoPublishViewController ()<GSBroadcastRoomDelegate, GSBroadcastVideoDelegate>
{
    BOOL videoFullScreen; //视频全屏
}
@property (weak, nonatomic) IBOutlet UIButton *openCamera;
@property (weak, nonatomic) IBOutlet UIButton *closeCamera;
@property (weak, nonatomic) IBOutlet UIButton *openMicrophone;
@property (weak, nonatomic) IBOutlet UIButton *closeMicrophone;

@property (assign, nonatomic)CGRect originalVideoFrame;
@property (assign, nonatomic)long long myUserID;
@property (assign, nonatomic)BOOL isCameraVideoDisplaying;
@property (assign, nonatomic)BOOL isLodVideoDisplaying;
@property (assign, nonatomic)BOOL isDesktopShareDisplaying;

@property (strong, nonatomic)MBProgressHUD *progressHUD;
@property (strong, nonatomic)GSBroadcastManager *broadcastManager;
@property (strong, nonatomic)GSVideoView *videoView;
@end

@implementation VideoPublishViewController
{
    AVCaptureVideoPreviewLayer *_previewLayer;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    [self.openCamera addTarget:self action:@selector(openMyCamera) forControlEvents:UIControlEventTouchUpInside];
    [self.closeCamera addTarget:self action:@selector(closeMyCamra) forControlEvents:UIControlEventTouchUpInside];
    [self.openMicrophone addTarget:self action:@selector(openMyMicrophone) forControlEvents:UIControlEventTouchUpInside];
    [self.closeMicrophone addTarget:self action:@selector(closeMyMicrophone) forControlEvents:UIControlEventTouchUpInside];
    
    [self setup];
    
    self.progressHUD = [[MBProgressHUD alloc]initWithView:self.navigationController.view];
    [self.navigationController.view addSubview:self.progressHUD];
    self.progressHUD.labelText =  NSLocalizedString(@"BroadcastConnecting",  @"直播连接提示");
    [self.progressHUD show:YES];
    
    [self initBroadCastManager];
    [self enterBackground];
    
    UIBarButtonItem *left = [[UIBarButtonItem alloc]initWithTitle:@"离开直播" style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = left;
    
    
}

- (void)back:(id)sender
{
    [self.progressHUD show:YES];
    self.progressHUD.labelText = @"Leaving...";
    [self.broadcastManager leaveAndShouldTerminateBroadcast:NO];
}


//设置后台运行
- (void)enterBackground
{
//    AVAudioSession *session = [AVAudioSession sharedInstance];
//    [session setCategory:AVAudioSessionCategoryPlayAndRecord error:nil];
//    [session setActive:YES error:nil];
}

//打开摄像头
- (void)openMyCamera
{
    // 开启美颜
    self.broadcastManager.beautifyFace = YES;
    
    // 打开摄像头
    [self.broadcastManager activateCamera:NO landscape:NO];
    
    // 设置预览视频View
    self.broadcastManager.videoView = self.videoView;
}

//关闭摄像头
- (void)closeMyCamra
{
    [self.broadcastManager inactivateCamera];
}

//打开麦克风
- (void)openMyMicrophone
{
    [self.broadcastManager activateMicrophone];
}

//关闭麦克风
- (void)closeMyMicrophone
{
    [self.broadcastManager inactivateMicrophone];
}

- (IBAction)beautifyFace:(id)sender {
    
    _broadcastManager.beautifyFace = !_broadcastManager.beautifyFace;
}

- (void)setup
{
    CGFloat y = self.navigationController.navigationBar.frame.size.height+[[UIApplication sharedApplication] statusBarFrame].size.height;
    
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    if (version < 7.0) {
        y -= 64;
    }
    
//    _originalVideoFrame = CGRectMake(0, y, self.view.frame.size.width, self.view.frame.size.width - 70);
    self.videoView = [[GSVideoView alloc]initWithFrame:self.view.bounds];
    
    self.videoView.userInteractionEnabled = NO;
    
    [self.view addSubview:self.videoView];
}

- (void)initBroadCastManager
{
    self.broadcastManager = [GSBroadcastManager sharedBroadcastManager];
    self.broadcastManager.broadcastRoomDelegate = self;
    self.broadcastManager.videoDelegate = self;
    
    
    if (![_broadcastManager connectBroadcastWithConnectInfo:self.connectInfo]) {
        
        [self.progressHUD show:NO];
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"WrongConnectInfo", @"参数不正确") delegate:self cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alertView show];
    }
}

#pragma mark - AlertView Delegate

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex{
    if (alertView.tag==1004)
    {
        
        if (buttonIndex==1) {
            
            
            dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_LOW, 0), ^(){
                
                GSDiagnosisInfo *DiagnosisInfo =[[GSDiagnosisInfo alloc] init];
                [DiagnosisInfo ReportDiagonse];
            });
            
        }else if (buttonIndex==0)
        {
            
        }
    }
    else if (alertView.tag == JoinFailed)
    {
        [self.navigationController popViewControllerAnimated:YES];
    }
    
}

#pragma mark -
#pragma mark GSBroadcastRoomDelegate


// 直播初始化代理
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveBroadcastConnectResult:(GSBroadcastConnectResult)result
{
    NSString *errorMsg = nil;
    
    switch (result) {
        case GSBroadcastConnectResultSuccess:
            
            // 直播初始化成功，加入直播
            if (![_broadcastManager join]) {
                errorMsg = @"加入失败";
            }
            break;
            
        case GSBroadcastConnectResultInitFailed:
        {
            errorMsg = @"初始化出错";
            break;
        }
            
        case GSBroadcastConnectResultJoinCastPasswordError:
        {
            errorMsg = @"口令错误";
            break;
        }
            
        case GSBroadcastConnectResultWebcastIDInvalid:
        {
            errorMsg = @"webcastID错误";
            break;
        }
            
        case GSBroadcastConnectResultRoleOrDomainError:
        {
            errorMsg = @"口令错误";
            break;
        }
            
        case GSBroadcastConnectResultLoginFailed:
        {
            errorMsg = @"登录信息错误";
            break;
        }
            
            
        case GSBroadcastConnectResultNetworkError:
        {
            errorMsg = @"网络错误";
            break;
        }
            
        case GSBroadcastConnectResultWebcastIDNotFound:
        {
            
            errorMsg = @"找不到对应的webcastID，roomNumber, domain填写有误";
            break;
        }
            
        case  GSBroadcastConnectResultThirdTokenError:
        {
            errorMsg = @"第三方验证错误";
            break;
        }
        default:
        {
            errorMsg = @"未知错误";
            break;
        }
    }
    
    
    if (errorMsg) {
        
        [_progressHUD hide:YES];
        
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:errorMsg delegate:self cancelButtonTitle:@"知道了" otherButtonTitles:nil, nil];
        alertView.tag = JoinFailed;
        [alertView show];
        
    }
}

/*
 直播连接代理
 rebooted为YES，表示这次连接行为的产生是由于根服务器重启而导致的重连
 */
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveBroadcastJoinResult:(GSBroadcastJoinResult)joinResult selfUserID:(long long)userID rootSeverRebooted:(BOOL)rebooted;
{
    [_progressHUD hide:YES];
    
    NSString * errorMsg = nil;
    
    switch (joinResult) {
            
            /**
             *  直播加入成功
             */
            
        case GSBroadcastJoinResultSuccess:
        {
            // 服务器重启导致重连的相应处理
            // 服务器重启的重连，直播中的各种状态将不再保留，如果想要实现重连后恢复之前的状态需要在本地记住，然后再重连成功后主动恢复。
            if (rebooted) {
                
                
            }
            
            _myUserID = userID;
            
            AppDelegate *appDelegate = (AppDelegate*)[[UIApplication sharedApplication] delegate];
            appDelegate.manager =  _broadcastManager;
            
            break;
        }
            
            /**
             *  未知错误
             */
        case GSBroadcastJoinResultUnknownError:
            errorMsg = @"未知错误";
            break;
            /**
             *  直播已上锁
             */
        case GSBroadcastJoinResultLocked:
            errorMsg = @"直播已上锁";
            break;
            /**
             *  直播组织者已经存在
             */
        case GSBroadcastJoinResultHostExist:
            errorMsg = @"直播组织者已经存在";
            break;
            /**
             *  直播成员人数已满
             */
        case GSBroadcastJoinResultMembersFull:
            errorMsg = @"直播成员人数已满";
            break;
            /**
             *  音频编码不匹配
             */
        case GSBroadcastJoinResultAudioCodecUnmatch:
            errorMsg = @"音频编码不匹配";
            break;
            /**
             *  加入直播超时
             */
        case GSBroadcastJoinResultTimeout:
            errorMsg = @"加入直播超时";
            break;
            /**
             *  ip被ban
             */
        case GSBroadcastJoinResultIPBanned:
            errorMsg = @"ip地址被ban";
            
            break;
            /**
             *  组织者还没有入会，加入时机太早
             */
        case GSBroadcastJoinResultTooEarly:
            errorMsg = @"直播尚未开始";
            break;
            
        default:
            errorMsg = @"未知错误";
            break;
    }
    
    if (errorMsg) {
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:errorMsg delegate:self cancelButtonTitle:@"知道了" otherButtonTitles:nil, nil];
        alertView.tag = JoinFailed;
        [alertView show];
        
    }
    
}


// 断线重连
- (void)broadcastManagerWillStartRoomReconnect:(GSBroadcastManager*)manager
{
    [_progressHUD show:YES];
    _progressHUD.labelText = @"正在重连...";
    
}


// 直播状态改变代理
- (void)broadcastManager:(GSBroadcastManager *)manager didSetStatus:(GSBroadcastStatus)status
{
    
}

// 自己离开直播代理
- (void)broadcastManager:(GSBroadcastManager*)manager didSelfLeaveBroadcastFor:(GSBroadcastLeaveReason)leaveReason
{
    [_broadcastManager invalidate];
    [_progressHUD hide:YES];
    [self.navigationController popViewControllerAnimated:YES];
}

- (BOOL) broadcastManager:(GSBroadcastManager *)manager querySettingsInfoKey:(NSString *)key numberValue:(int *)value
{
    if ([key isEqualToString:@"save.video.height"]) {
        *value = 352;
    }else if ([key isEqualToString:@"save.video.width"])
    {
        *value = 288;
    }
    return YES;
}

#pragma mark -
#pragma mark GSBroadcastVideoDelegate

// 视频模块连接代理
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveVideoModuleInitResult:(BOOL)result
{
    
}

// 摄像头是否可用代理
- (void)broadcastManager:(GSBroadcastManager*)manager isCameraAvailable:(BOOL)isAvailable
{
    
}

// 摄像头打开代理
- (void)broadcastManagerDidActivateCamera:(GSBroadcastManager*)manager
{
    [_broadcastManager setVideo:_myUserID active:YES];
}

// 摄像头关闭代理
- (void)broadcastManagerDidInactivateCamera:(GSBroadcastManager*)manager
{
    
}

// 收到一路视频
- (void)broadcastManager:(GSBroadcastManager*)manager didUserJoinVideo:(GSUserInfo *)userInfo
{
}

// 某个用户退出视频
- (void)broadcastManager:(GSBroadcastManager*)manager didUserQuitVideo:(long long)userID
{
    
}

// 某一路摄像头视频被激活
- (void)broadcastManager:(GSBroadcastManager*)manager didSetVideo:(GSUserInfo*)userInfo active:(BOOL)active
{
}

// 某一路视频被订阅代理
- (void)broadcastManager:(GSBroadcastManager*)manager didDisplayVideo:(GSUserInfo*)userInfo
{
    
}

// 某一路视频取消订阅代理
- (void)broadcastManager:(GSBroadcastManager*)manager didUndisplayVideo:(long long)userID
{
}


// 摄像头或插播视频每一帧的数据代理，软解
- (void)broadcastManager:(GSBroadcastManager*)manager userID:(long long)userID renderVideoFrame:(GSVideoFrame*)videoFrame
{
}


// 硬解数据从这个代理返回
- (void)OnVideoData4Render:(long long)userId width:(int)nWidth nHeight:(int)nHeight frameFormat:(unsigned int)dwFrameFormat displayRatio:(float)fDisplayRatio data:(void *)pData len:(int)iLen
{
   }

/**
 *  手机摄像头开始采集数据
 *
 *  @param manager 触发此代理的GSBroadcastManager对象
 */
- (BOOL)broadcastManagerDidStartCaptureVideo:(GSBroadcastManager*)manager
{
    [self openMyCamera];
    return YES;
}

/**
 手机摄像头停止采集数据
 */
- (void)broadcastManagerDidStopCaptureVideo:(GSBroadcastManager*)manager
{
}

#pragma mark -
#pragma mark GSBroadcastAudioDelegate

// 音频模块连接代理
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveAudioModuleInitResult:(BOOL)result
{
    
}

#pragma mark -
#pragma mark System Default Code

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)dealloc
{

    
}

@end
