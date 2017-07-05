//
//  SecondInitViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 3/16/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "SecondInitViewController.h"
#import "UserDefaults.h"
#import "MainTableViewController.h"

@interface SecondInitViewController () <UITextFieldDelegate>

@property (weak, nonatomic) IBOutlet UITextField *roomNumberTextField;

@property (weak, nonatomic) IBOutlet UITextField *webcastTextField;

@property (weak, nonatomic) IBOutlet UITextField *nicknameTextField;

@property (weak, nonatomic) IBOutlet UITextField *watchPasswordTextField;

@property (weak, nonatomic) IBOutlet UITextField *tokenTextField;

@property (strong, nonatomic) NSArray *textFileds;

@property (strong, nonatomic) UITextField *activatedTextField;

@property (strong, nonatomic)NSDictionary *keyboadUserInfo;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *topConstraint;

@end

@implementation SecondInitViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    if (version < 7.0) {
        self.topConstraint.constant -= 64;
    }
    
    [self setup];
    
    [self addNotifications];
}

- (void)setup
{
    self.title = NSLocalizedString(@"Title", nil);

    self.roomNumberTextField.text = [UserDefaults roomNumber];
    self.roomNumberTextField.delegate = self;
    
    self.webcastTextField.text = [UserDefaults webcastID];
    self.webcastTextField.delegate = self;
    
    self.nicknameTextField.text = [UserDefaults nickname];
    self.nicknameTextField.delegate = self;
    
    self.watchPasswordTextField.text = [UserDefaults watchPassword];
    self.watchPasswordTextField.delegate = self;
    
}

#pragma mark -
#pragma mark Notifications

- (void)addNotifications
{
    [[NSNotificationCenter defaultCenter]addObserver:self selector:@selector(keyNotification:) name:UIKeyboardWillChangeFrameNotification object:nil];
}

- (void)removeNotifications
{
    [[NSNotificationCenter defaultCenter]removeObserver:self];
}

- (void)keyNotification:(NSNotification*)notification
{
    self.keyboadUserInfo = notification.userInfo;
    
    CGRect rect = [notification.userInfo[@"UIKeyboardFrameEndUserInfoKey"] CGRectValue];
    
    [UIView animateWithDuration:[notification.userInfo[UIKeyboardAnimationDurationUserInfoKey]floatValue] animations: ^{
        
        [UIView setAnimationCurve:[notification.userInfo[UIKeyboardAnimationCurveUserInfoKey] doubleValue]];
        
        
        CGRect frame = self.view.frame;
        CGFloat offY = _activatedTextField.frame.origin.y + _activatedTextField.frame.size.height - rect.origin.y;
        
        frame.origin.y = offY > 0 ? -offY - 5 : 0;
        
        self.view.frame = frame;
    }];
    
}


#pragma mark -
#pragma mark Actions

//- (IBAction)startBroadcast:(id)sender {

//    GSConnectInfo *connectInfo = [GSConnectInfo new];
//    connectInfo.domain = self.domain;
//    connectInfo.serviceType = self.serviceType;
//    connectInfo.loginName = self.loginName;
//    connectInfo.loginPassword = self.loginPassword;
//    connectInfo.roomNumber = self.roomNumberTextField.text;
//    connectInfo.webcastID = self.webcastTextField.text;
//    connectInfo.nickName = self.nicknameTextField.text;
//    connectInfo.watchPassword = self.watchPasswordTextField.text;
    
    // 页面跳转
//    UIStoryboard *board = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];

//    ItemViewController* viewController = [board instantiateViewControllerWithIdentifier:@"ItemVC"];
//    viewController.broadcastManager = self.broadcastManager;
    
//    [self.navigationController pushViewController:viewController animated:YES];

    

//    [self.broadcastManager connectRoomWithRoomConnectionInfo:connectInfo];
    
//}

-(void)touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event
{
    [self.view endEditing:YES];
}


#pragma mark -
#pragma mark System Default Code

- (void)dealloc
{
    [self removeNotifications];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    MainTableViewController *controller = segue.destinationViewController;
    controller.domain = self.domain;
    controller.loginName = self.loginName;
    controller.loginPassword = self.loginPassword;
    controller.serviceType = self.serviceType;
    controller.webcastID = self.webcastTextField.text;
    controller.roomNumber = self.roomNumberTextField.text;
    controller.nickName = self.nicknameTextField.text;
    controller.watchPassword = self.watchPasswordTextField.text;
    controller.token = self.tokenTextField.text;
}



@end
