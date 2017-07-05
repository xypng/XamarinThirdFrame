//
//  DocViewController.m
//  PlayerSDKDemo
//
//  Created by Gaojin Hsu on 6/29/15.
//  Copyright (c) 2015 Geensee. All rights reserved.
//

#import "DocViewController.h"
#import "AppDelegate.h"
#import "MBProgressHUD.h"

@interface DocViewController () <GSPPlayerManagerDelegate,GSPDocViewDelegate>{
    CGRect docViewRect;//记录docView的原始尺寸
    BOOL hasOrientation;
}

@property (nonatomic, strong) GSPDocView *docView;

@property (nonatomic, strong) MBProgressHUD *progressHUD;

@property(nonatomic,assign)BOOL isDocFullMode;


@end

@implementation DocViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    [self.view setBackgroundColor:[UIColor colorWithWhite:0.95 alpha:1.0]];
    self.playerManager.delegate = self;
    
    [self.playerManager enableVideo:NO];
    [self.playerManager enableAudio:YES];
    
    CGFloat y = [[UIApplication sharedApplication]statusBarFrame].size.height + self.navigationController.navigationBar.frame.size.height;
    
    //适配iOS6
    if ([[[UIDevice currentDevice] systemVersion] floatValue] < 7.0) {
        y = 0;
    }
    
    docViewRect = CGRectMake(0, y, self.view.bounds.size.width, self.view.bounds.size.height/2);
    
    _docView = [[GSPDocView alloc]initWithFrame:docViewRect];
    _docView.backgroundColor = [UIColor whiteColor];
    [self.view addSubview:_docView];
    [_docView setGlkBackgroundColor:51 green:51 blue:51];
    
    _docView.gSDocModeType=ScaleAspectFit;
    _docView.pdocDelegate=self;
    _docView.hidden=YES;
    
    
    self.playerManager.docView = _docView;
    //全屏
    UITapGestureRecognizer *tapGestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(rotationdocView:)];
    tapGestureRecognizer.numberOfTapsRequired = 2;
    [_docView addGestureRecognizer:tapGestureRecognizer];
    
}



-(void)handleDocViewModeSwitch:(UITapGestureRecognizer*)recognizer
{
    
    _isDocFullMode=!_isDocFullMode;
    if (_docView) {
       // [_docView setFullMode:_isDocFullMode];
    }
    
    
    
}




- (void)rotationdocView:(UIGestureRecognizer *)gestureRecognizer {
    //强制旋转
    if (!hasOrientation) {
        [UIView animateWithDuration:0.5 animations:^{
            self.view.transform = CGAffineTransformMakeRotation(M_PI/2);
            self.view.frame = CGRectMake(0, 0, [UIScreen mainScreen].bounds.size.height, [UIScreen mainScreen].bounds.size.width);
            _docView.frame = CGRectMake(0, 0, [UIScreen mainScreen].bounds.size.height, [UIScreen mainScreen].bounds.size.width);
            hasOrientation = YES;
            self.navigationController.navigationBarHidden = YES;
            [[UIApplication sharedApplication] setStatusBarHidden:YES];
            
            _docView.zoomEnabled = YES;
        }];
    } else {
        [UIView animateWithDuration:0.5 animations:^{
            self.view.transform = CGAffineTransformInvert(CGAffineTransformMakeRotation(0));
            self.view.frame = CGRectMake(0, 0, [UIScreen mainScreen].bounds.size.width, [UIScreen mainScreen].bounds.size.height);
            _docView.frame = docViewRect;
            hasOrientation = NO;
            [[UIApplication sharedApplication] setStatusBarHidden:NO];
            self.navigationController.navigationBarHidden = NO;
            _docView.zoomEnabled = NO;
        }];
    }
}

- (BOOL)shouldAutorotate {
    return NO;
}

- (void)playerManager:(GSPPlayerManager *)playerManager didSelfLeaveFor:(GSPLeaveReason)reason {
    NSString *reasonStr = nil;
    switch (reason) {
        case GSPLeaveReasonEjected:
            reasonStr = NSLocalizedString(@"被踢出直播", @"");
            break;
        case GSPLeaveReasonTimeout:
            reasonStr = NSLocalizedString(@"超时", @"");
            break;
        case GSPLeaveReasonClosed:
            reasonStr = NSLocalizedString(@"直播关闭", @"");
            break;
        case GSPLeaveReasonUnknown:
            reasonStr = NSLocalizedString(@"位置错误", @"");
            break;
        default:
            break;
    }
    if (reasonStr != nil) {
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:NSLocalizedString(@"退出直播", @"") message:reasonStr delegate:self cancelButtonTitle:NSLocalizedString(@"知道了", @"") otherButtonTitles:nil];
        [alertView show];
    }
    
}

- (void)playerManagerWillReconnect:(GSPPlayerManager *)playerManager {
    _progressHUD = [[MBProgressHUD alloc] initWithView:_docView];
    _progressHUD.labelText = NSLocalizedString(@"断线重连", @"");
    [self.view addSubview:_progressHUD];
    [_progressHUD show:YES];
}

- (void)playerManager:(GSPPlayerManager *)playerManager didReceiveSelfJoinResult:(GSPJoinResult)joinResult {
    NSString *result = @"";
    switch (joinResult) {
        case GSPJoinResultCreateRtmpPlayerFailed:
            result = NSLocalizedString(@"创建直播实例失败", @"");
            break;
        case GSPJoinResultJoinReturnFailed:
            result = NSLocalizedString(@"调用加入直播失败", @"");
            break;
        case GSPJoinResultNetworkError:
            result = NSLocalizedString(@"网络错误", @"");
            break;
        case GSPJoinResultUnknowError:
            result = NSLocalizedString(@"未知错误", @"");
            break;
        case GSPJoinResultParamsError:
            result = NSLocalizedString(@"参数错误", @"");
            break;
        case GSPJoinResultOK:
            result = @"加入成功";
            break;
        case GSPJoinResultCONNECT_FAILED:
            result = NSLocalizedString(@"连接失败", @"");
            break;
        case GSPJoinResultTimeout:
            result = NSLocalizedString(@"连接超时", @"");
            break;
        case GSPJoinResultRTMP_FAILED:
            result = NSLocalizedString(@"链接媒体服务器失败", @"");
            break;
        case GSPJoinResultTOO_EARLY:
            result = NSLocalizedString(@"直播尚未开始", @"");
            break;
        case GSPJoinResultLICENSE:
            result = NSLocalizedString(@"人数已满", @"");
            break;
        default:
            result = NSLocalizedString(@"错误", @"");
            break;
    }
    
    //用于断线重连
    if (_progressHUD != nil) {
        [_progressHUD hide:YES];
        _progressHUD = nil;
    }
    
    UIAlertView *alertView;
    if ([result isEqualToString:@"加入成功"]) {
    } else {
        alertView = [[UIAlertView alloc] initWithTitle:result message:NSLocalizedString(@"请退出重试", @"") delegate:self cancelButtonTitle:NSLocalizedString(@"知道了", @"") otherButtonTitles:nil];
        [self.view addSubview:alertView];
        [alertView show];
    }
    
    
}

- (void)playerManager:(GSPPlayerManager *)playerManager didUserJoin:(GSPUserInfo *)userInfo {
    //用于断线重连
    if (_progressHUD != nil) {
        [_progressHUD hide:YES];
        _progressHUD = nil;
    }
}



#pragma mark ----GSPDocViewDelegate-----
- (void)docViewPOpenFinishSuccess:(GSPDocPage*)page   docID:(unsigned)docID
{


    if (_docView.hidden) {
        _docView.hidden=NO;
    }
    
}




- (void)dealloc {
    
   // [_docView clearPageAndAnno];
    
    [self.playerManager leave];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
- (IBAction)openMic:(id)sender {
//    [self.playerManager activateMicrophone:YES];
    
    [self.playerManager leave];
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
