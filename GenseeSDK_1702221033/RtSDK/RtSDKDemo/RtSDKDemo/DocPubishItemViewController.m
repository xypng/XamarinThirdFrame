//
//  DocPubishItemViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 6/27/16.
//  Copyright © 2016 gensee. All rights reserved.
//

#import "DocPubishItemViewController.h"
#import "MBProgressHUD.h"


#define   BlackColor [UIColor colorWithRed:0/255.0 green:0/255.0 blue:0/255.0 alpha:1]
#define   WhiteColor [UIColor colorWithRed:255/255.0 green:255/255.0 blue:255/255.0 alpha:1]
#define   RedColor   [UIColor colorWithRed:255/255.0 green:0/255.0 blue:0/255.0 alpha:1]
#define   GreenColor [UIColor colorWithRed:0/255.0 green:255/255.0 blue:0/255.0 alpha:1]
#define   BlueColor  [UIColor colorWithRed:0/255.0 green:0/255.0 blue:255/255.0 alpha:1]



@interface DocPubishItemViewController()<GSBroadcastRoomDelegate, GSBroadcastDocumentDelegate, UINavigationControllerDelegate,UIImagePickerControllerDelegate,GestureDocPanelViewDelegate>

@property (strong, nonatomic)GSBroadcastManager *broadcastManager;
@property (strong, nonatomic)GSDocView *docView;
@property (strong, nonatomic)MBProgressHUD *progressHUD;


@property(assign,nonatomic)BOOL isAnnotationMode;  //是否标注模式

@property(assign,nonatomic)CGFloat originalY;

@end

@implementation DocPubishItemViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    // 注意下列代码的顺序
    [self setup];
    
    self.progressHUD = [[MBProgressHUD alloc]initWithView:self.navigationController.view];
    [self.navigationController.view addSubview:self.progressHUD];
    self.progressHUD.labelText =  NSLocalizedString(@"BroadcastConnecting",  @"直播连接提示");
    [self.progressHUD show:YES];
    
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

- (void)initBroadCastManager
{
    self.broadcastManager = [GSBroadcastManager sharedBroadcastManager];
    
    // 注意下列代码的顺序
    self.broadcastManager.documentView = self.docView;
    self.broadcastManager.broadcastRoomDelegate = self;
    self.broadcastManager.documentDelegate = self;
    
    if (![_broadcastManager connectBroadcastWithConnectInfo:self.connectInfo]) {
        
        [self.progressHUD show:NO];
        UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"WrongConnectInfo", @"参数不正确") delegate:self cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alertView show];
        
    }
    
}

- (void)setup
{
    
    
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    CGFloat y;
    
    if (version < 7.0) {
        y = 0;
    }
    else
    {
        if (version >= 8.0)
        {
            self.automaticallyAdjustsScrollViewInsets = NO;
        }
        y = [[UIApplication sharedApplication]statusBarFrame].size.height + self.navigationController.navigationBar.frame.size.height;
    }
    
    self.docView = [[GSDocView alloc]initWithFrame:CGRectMake(0, y, self.view.frame.size.width, self.view.frame.size.height/2)];
    
    _originalY=y+self.view.frame.size.height/2;
    
    self.docView.backgroundColor = [UIColor clearColor];
    self.docView.zoomEnabled = YES;
    self.docView.fullMode = YES;
    [self.view addSubview:self.docView];
    
    
    
    _isAnnotationMode=NO;
    [self setupGestureDocPanelView];
    
}


-(void)setupGestureDocPanelView
{
    
    _gestureDocPanelView=[[GestureDocPanelView alloc] initWithFrame:CGRectMake(0, _originalY, 320, 44)];
    
    _gestureDocPanelView.docPaneDelegate=self;
    
    [self.view addSubview:_gestureDocPanelView];
    
    
}





#pragma mark GestureDocPanelViewDelegate


-(void)setUpAnnotationMode
{
    
    _isAnnotationMode=!_isAnnotationMode;
    
    self.docView.isAnnomationModeOpen=_isAnnotationMode;
    
    _gestureDocPanelView.isOpenAnnotation=_isAnnotationMode;
    
    
    
    
    if (_isAnnotationMode) {
        //  [self removeAllGesture];   //开启标注模式，移除app在GSDocView上面的手势，防止和标注手势冲突
    }else{
        
        // [self addAllGesture];      //关闭标注模式，重新添加app在GSDocView上面的手势
    }
    
    
    
}


- (void)setAnnoMode:(int)annoMode
{
    
    switch (annoMode) {
        case 1:
        {
            [self setUpAnnotationMode];
        }
            break;
        case 2:
        {
            [self.docView setupDocAnnoType:GSDocumentAnnoTypeFreePen];  //GSDocumentAnnoTypeFreePenEx
        }
            break;
        case 3:
        {
            [self.docView setupDocAnnoType:GSDocumentAnnoTypeFreePenEx];  //GSDocumentAnnoTypeCircle
        }
            break;
        case 4:
        {
            
               [self.docView setupDocAnnoType:GSDocumentAnnoTypeRect];
          
        }
            break;
        case 5:
        {
          
            
           //[self.docView setupDocAnnoType:GSDocumentAnnoTypeLine];
           //[self.docView setupDocAnnoType:GSDocumentAnnoTypeCircle];
            
            
            [self.docView setupDocAnnoType:GSDocumentAnnoTypePointEx];
            
            //[self.docView setupDocAnnoType:GSDocumentAnnoTypeLineEx];
            //[self.docView setupLineExAnnoType:LineExArrowAnnoType];
            
            
        }
            break;
            
        case 6:
        {
            
            
             [self.docView setupDocAnnoType:GSDocumentAnnoTypeCleaner];
            
           // [self.docView setupClearAnnoType:GSDocumentAnnoClearAllType];
            
            
        }
            break;
            
        case 7:
        {
            
            [self.docView setupDocAnnoLineSize:10];
            [self.docView setupDocAnnoColor:BlueColor];
            
        }
            break;
            
        default:
            break;
    }
    
    
}









#pragma mark -
#pragma mark GSBroadcastRoomDelegate

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
    
    if (joinResult == GSBroadcastJoinResultSuccess)
    {
        BOOL a = [_broadcastManager setBroadcastInfo:@"user.rostrum" value:userID];
        NSLog(@"%d", a);
    }else
    {
        NSLog(@"Error");
    }
    
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
#pragma mark GSBroadcastDocDelegate

// 文档模块连接代理
- (void)broadcastManager:(GSBroadcastManager*)manager didReceiveDocModuleInitResult:(BOOL)result
{
}

// 文档打开代理
- (void)broadcastManager:(GSBroadcastManager *)manager didOpenDocument:(GSDocument *)doc
{
    
}

// 文档关闭代理
- (void)broadcastManager:(GSBroadcastManager *)manager didCloseDocument:(unsigned int)docID
{
    
}

// 文档切换代理
- (void)broadcastManager:(GSBroadcastManager *)manager didSlideToPage:(unsigned int)pageID ofDoc:(unsigned int)docID step:(int)step
{
    
}

- (IBAction)publishDoc:(id)sender {
    
    UIImagePickerController* imageController = [[UIImagePickerController alloc] init];
    imageController.delegate = self;
    imageController.sourceType = UIImagePickerControllerSourceTypePhotoLibrary;
    imageController.allowsEditing = NO;
    //    imageController.wantsFullScreenLayout = YES;
    
    UIImagePickerControllerSourceType sourceType = UIImagePickerControllerSourceTypeCamera;
    if (![UIImagePickerController isSourceTypeAvailable: UIImagePickerControllerSourceTypeCamera])
    {
        UIAlertView *alertView = [[UIAlertView alloc] initWithTitle:@"Error" message:@"Camera is unavailable on your device" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles: nil];
        [alertView show];
        
        return;
    }
    imageController.sourceType = sourceType;
    //    imageController.mediaTypes = [NSArray arrayWithObjects:@"public.movie", @"public.image", nil];
    
    [self presentModalViewController:imageController animated:YES];
    
}

- (void)imagePickerController:(UIImagePickerController *)picker didFinishPickingMediaWithInfo:(NSDictionary<NSString *,id> *)info
{
    NSString *mediaType = [info objectForKey:UIImagePickerControllerMediaType];
    
    
    UIImage* imageItem;
    
    if ([mediaType isEqualToString:@"public.image"]){
        
        imageItem= [info objectForKey:UIImagePickerControllerOriginalImage];
    }
    
    if(imageItem == nil)
    {
        UIAlertView* alert = [[UIAlertView alloc]initWithTitle:nil message:@"选择图片失败,请重新选择" delegate:nil cancelButtonTitle:@"确定" otherButtonTitles:nil, nil];
        [alert show];
        return;
    }
    
    
    
    //    NSString* titleTextName=[[LiveMgr shareInstance] getNameForPublishImage];
    
    unsigned int m_docId= [self.broadcastManager publishDocOpen:@"example"];
    unsigned int pageHandle=0;
    
    
    
    //
    CGFloat imageH= imageItem.size.height;
    CGFloat imageW= imageItem.size.width;
    
    int bitCounts=32;
    NSString* titleText=@"example";
    NSString* fullText=@"example";
    
    NSString* aniCfg=@"";
    NSString* pageComment=@"";
    
    //    NSData *imageData = 0(imageItem);
    
    NSData *imageData = UIImageJPEGRepresentation([self scaleAndRotateImage: imageItem],0.93);
    
    
    
    BOOL isSuccess=   [self.broadcastManager publishDocTranslataData:m_docId pageHandle:pageHandle pageWidth:imageW pageHeight:imageH bitCounts:bitCounts titleText:titleText fullText:fullText aniCfg:aniCfg pageComment:pageComment data:imageData];
    
    
    [self.broadcastManager publishDocTranslateEnd:m_docId bSuccess:isSuccess];
    
    
    [self.broadcastManager publishDocGotoPage:m_docId pageId:0 sync2other:YES];
    
    [picker dismissViewControllerAnimated:YES completion:nil];
    
}

- (UIImage *)scaleAndRotateImage:(UIImage *)image {
    
    int kMaxResolution = 640; // Or whatever
    
    CGImageRef imgRef = image.CGImage;
    
    CGFloat width = CGImageGetWidth(imgRef);
    CGFloat height = CGImageGetHeight(imgRef);
    
    
    CGAffineTransform transform = CGAffineTransformIdentity;
    CGRect bounds = CGRectMake(0, 0, width, height);
    if (width > kMaxResolution || height > kMaxResolution) {
        CGFloat ratio = width/height;
        if (ratio > 1) {
            bounds.size.width = kMaxResolution;
            bounds.size.height = roundf(bounds.size.width / ratio);
        }
        else {
            bounds.size.height = kMaxResolution;
            bounds.size.width = roundf(bounds.size.height * ratio);
        }
    }
    
    CGFloat scaleRatio = bounds.size.width / width;
    CGSize imageSize = CGSizeMake(CGImageGetWidth(imgRef), CGImageGetHeight(imgRef));
    CGFloat boundHeight;
    UIImageOrientation orient = image.imageOrientation;
    switch(orient) {
            
        case UIImageOrientationUp: //EXIF = 1
            transform = CGAffineTransformIdentity;
            break;
            
        case UIImageOrientationUpMirrored: //EXIF = 2
            transform = CGAffineTransformMakeTranslation(imageSize.width, 0.0);
            transform = CGAffineTransformScale(transform, -1.0, 1.0);
            break;
            
        case UIImageOrientationDown: //EXIF = 3
            transform = CGAffineTransformMakeTranslation(imageSize.width, imageSize.height);
            transform = CGAffineTransformRotate(transform, M_PI);
            break;
            
        case UIImageOrientationDownMirrored: //EXIF = 4
            transform = CGAffineTransformMakeTranslation(0.0, imageSize.height);
            transform = CGAffineTransformScale(transform, 1.0, -1.0);
            break;
            
        case UIImageOrientationLeftMirrored: //EXIF = 5
            boundHeight = bounds.size.height;
            bounds.size.height = bounds.size.width;
            bounds.size.width = boundHeight;
            transform = CGAffineTransformMakeTranslation(imageSize.height, imageSize.width);
            transform = CGAffineTransformScale(transform, -1.0, 1.0);
            transform = CGAffineTransformRotate(transform, 3.0 * M_PI / 2.0);
            break;
            
        case UIImageOrientationLeft: //EXIF = 6
            boundHeight = bounds.size.height;
            bounds.size.height = bounds.size.width;
            bounds.size.width = boundHeight;
            transform = CGAffineTransformMakeTranslation(0.0, imageSize.width);
            transform = CGAffineTransformRotate(transform, 3.0 * M_PI / 2.0);
            break;
            
        case UIImageOrientationRightMirrored: //EXIF = 7
            boundHeight = bounds.size.height;
            bounds.size.height = bounds.size.width;
            bounds.size.width = boundHeight;
            transform = CGAffineTransformMakeScale(-1.0, 1.0);
            transform = CGAffineTransformRotate(transform, M_PI / 2.0);
            break;
            
        case UIImageOrientationRight: //EXIF = 8
            boundHeight = bounds.size.height;
            bounds.size.height = bounds.size.width;
            bounds.size.width = boundHeight;
            transform = CGAffineTransformMakeTranslation(imageSize.height, 0.0);
            transform = CGAffineTransformRotate(transform, M_PI / 2.0);
            break;
            
        default:
            [NSException raise:NSInternalInconsistencyException format:@"Invalid image orientation"];
            
    }
    
    UIGraphicsBeginImageContext(bounds.size);
    
    CGContextRef context = UIGraphicsGetCurrentContext();
    
    if (orient == UIImageOrientationRight || orient == UIImageOrientationLeft) {
        CGContextScaleCTM(context, -scaleRatio, scaleRatio);
        CGContextTranslateCTM(context, -height, 0);
    }
    else {
        CGContextScaleCTM(context, scaleRatio, -scaleRatio);
        CGContextTranslateCTM(context, 0, -height);
    }
    
    CGContextConcatCTM(context, transform);
    
    CGContextDrawImage(UIGraphicsGetCurrentContext(), CGRectMake(0, 0, width, height), imgRef);
    UIImage *imageCopy = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    
    return imageCopy;
}


#pragma mark -
#pragma mark System Default Code

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)dealloc
{
    [self.broadcastManager leaveAndShouldTerminateBroadcast:YES];
    [self.broadcastManager invalidate];
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
