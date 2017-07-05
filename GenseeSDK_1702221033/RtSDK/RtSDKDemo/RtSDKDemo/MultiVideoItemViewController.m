//
//  MultiVideoItemViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 4/6/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "MultiVideoItemViewController.h"
#import "MBProgressHUD.h"

@interface MultiVideoItemViewController () <GSBroadcastRoomDelegate, GSBroadcastVideoDelegate, GSBroadcastAudioDelegate>

@property (strong, nonatomic)GSBroadcastManager *broadcastManager;

@property (strong, nonatomic)MBProgressHUD *progressHUD;

@property (strong, nonatomic)NSMutableDictionary *videoviewDic;

@property (strong, nonatomic)NSMutableDictionary *videoViewFrameDic;

@property (strong, nonatomic)UIScrollView *scrollView;

@property (assign, nonatomic)int x;

@property (assign, nonatomic)int y;

@end

@implementation MultiVideoItemViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.progressHUD = [[MBProgressHUD alloc]initWithView:self.navigationController.view];
    [self.navigationController.view addSubview:self.progressHUD];
    self.progressHUD.labelText =  NSLocalizedString(@"BroadcastConnecting",  @"直播连接提示");
    [self.progressHUD show:YES];
    
    _videoviewDic = [NSMutableDictionary dictionary];
    _videoViewFrameDic = [NSMutableDictionary dictionary];
    
    _scrollView = [[UIScrollView alloc]initWithFrame:self.view.bounds];
    [self.view addSubview: _scrollView];
    
    
    UIBarButtonItem *left = [[UIBarButtonItem alloc]initWithTitle:@"退出直播" style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = left;

    
    [self initBroadCastManager];
}

- (void)back:(id)sender
{
    [self.progressHUD show:YES];
    self.progressHUD.labelText = @"Leaving...";
    [self.broadcastManager leaveAndShouldTerminateBroadcast:NO];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)initBroadCastManager
{
    _broadcastManager = [GSBroadcastManager sharedBroadcastManager];
    _broadcastManager.broadcastRoomDelegate = self;
    _broadcastManager.videoDelegate = self;
    _broadcastManager.audioDelegate = self;
    
    if (![_broadcastManager connectBroadcastWithConnectInfo:self.connectInfo]) {
        
        [_progressHUD show:NO];
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"WrongConnectInfo", @"参数不正确") delegate:self cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alertView show];
        
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
    
}

// 摄像头关闭代理
- (void)broadcastManagerDidInactivateCamera:(GSBroadcastManager*)manager
{
    
}

// 收到一路视频
- (void)broadcastManager:(GSBroadcastManager*)manager didUserJoinVideo:(GSUserInfo *)userInfo
{
    // 只要有人打开视频，就去订阅它
    [_broadcastManager displayVideo:userInfo.userID];
    
    
    // 针对不同的userID的视频，分别创建一个videoView，存在字典中。
    GSVideoView *videoView;
    if ([_videoViewFrameDic objectForKey:[NSNumber numberWithLongLong:userInfo.userID]]) {
        
        videoView = [[GSVideoView alloc]initWithFrame:[[_videoViewFrameDic objectForKey:[NSNumber numberWithLongLong:userInfo.userID]]CGRectValue]];
    }
    else
    {
        videoView = [[GSVideoView alloc]initWithFrame:CGRectMake((_x%2)*self.view.bounds.size.width/2, _y, self.view.bounds.size.width/2.f, self.view.bounds.size.width/2.f*3.f/4.f)];
        videoView.backgroundColor = [UIColor redColor];
        [_videoViewFrameDic setObject:[NSValue valueWithCGRect:videoView.frame]forKey:[NSNumber numberWithLongLong:userInfo.userID]];
        
        if (_y + self.view.bounds.size.width/2.f*3.f/4.f > self.view.bounds.size.height) {
            [_scrollView setContentSize:CGSizeMake(self.view.frame.size.width, _y + self.view.bounds.size.width/2.f*3.f/4.f)];
        }
        
    }
    [_scrollView addSubview:videoView];
    [_videoviewDic setObject:videoView forKey:[NSNumber numberWithLongLong:userInfo.userID]];
  
    
    // 计算下一个新增视频的origin
    _x++;
    if (_x%2 == 0)
    {
        _y += self.view.bounds.size.width/2.f*3.f/4.f;
    }
}

// 某个用户退出视频
- (void)broadcastManager:(GSBroadcastManager*)manager didUserQuitVideo:(long long)userID
{
    [((GSVideoView*)[_videoviewDic objectForKey:[NSNumber numberWithLongLong:userID]]) removeFromSuperview];
    
    [_videoviewDic removeObjectForKey:[NSNumber numberWithLongLong:userID]];
    
    
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
    [((GSVideoView*)[_videoviewDic objectForKey:[NSNumber numberWithLongLong:userId]]) hardwareAccelerateRender:pData size:iLen dwFrameFormat:dwFrameFormat ];
}

/**
 *  手机摄像头开始采集数据
 *
 *  @param manager 触发此代理的GSBroadcastManager对象
 */
- (BOOL)broadcastManagerDidStartCaptureVideo:(GSBroadcastManager*)manager
{
    return NO;
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


@end
