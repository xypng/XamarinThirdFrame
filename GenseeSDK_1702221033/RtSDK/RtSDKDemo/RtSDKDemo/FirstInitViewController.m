//
//  FirstInitViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 3/13/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "FirstInitViewController.h"
#import "UserDefaults.h"
#import "SecondInitViewController.h"

@interface FirstInitViewController () <UITextFieldDelegate>

@property (weak, nonatomic) IBOutlet UITextField *domainTextField;

@property (weak, nonatomic) IBOutlet UITextField * serviceTypeTextField;

@property (weak, nonatomic) IBOutlet UITextField * loginNameTextField;

@property (weak, nonatomic) IBOutlet UITextField * loginPasswordTextField;

@property (strong, nonatomic)NSArray *textFields;

@property (strong, nonatomic)UITextField *activatedTextField;

@property (strong, nonatomic)NSDictionary *keyboadUserInfo;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *topConstraint;

@end

@implementation FirstInitViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    
    double version = [[UIDevice currentDevice].systemVersion doubleValue];//判定系统版本。
    if (version < 7.0) {
        self.topConstraint.constant -= 64;
    }

    [self setup];
    [self addNotifications];
}

-(void)setup
{
    self.title = NSLocalizedString(@"Title", nil);
    
    self.domainTextField.text = [UserDefaults domain];
    self.domainTextField.delegate = self;
    
    self.serviceTypeTextField.text = [UserDefaults serviceType];
    self.serviceTypeTextField.delegate = self;
    
    self.loginNameTextField.text = [UserDefaults loginName];
    self.loginNameTextField.delegate = self;
    
    self.loginPasswordTextField.text = [UserDefaults loginPassword];
    self.loginPasswordTextField.delegate = self;
    
    self.textFields = @[_domainTextField, _serviceTypeTextField, _loginNameTextField, _loginPasswordTextField];
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

- (void)touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event
{
    [self.view endEditing:YES];
}

#pragma mark -
#pragma mark - UITextFiledDelegate

- (void)textFieldDidBeginEditing:(UITextField *)textField
{
    _activatedTextField = textField;
}

- (BOOL)textFieldShouldReturn:(UITextField *)textField
{
    NSUInteger currentIndex = [_textFields indexOfObject:textField];
    
    if (currentIndex != _textFields.count - 1) {
        
        [(UITextField*)_textFields[currentIndex]resignFirstResponder];
        [(UITextField*)_textFields[currentIndex + 1]becomeFirstResponder];
    }
    else
    {
        [self performSegueWithIdentifier:@"firstSegue" sender:self];
    }
    return YES;
}

#pragma mark -
#pragma mark System Default Code

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    SecondInitViewController *destinationViewController = (SecondInitViewController*)segue.destinationViewController;
    destinationViewController.domain = self.domainTextField.text;
    destinationViewController.serviceType = self.serviceTypeTextField.text;
    destinationViewController.loginName = self.loginNameTextField.text;
    destinationViewController.loginPassword = self.loginPasswordTextField.text;
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)dealloc
{
    [self removeNotifications];
}

@end
