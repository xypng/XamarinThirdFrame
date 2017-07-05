//
//  MainTableViewController.m
//  iOSDemo
//
//  Created by Gaojin Hsu on 3/16/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import "MainTableViewController.h"
#import "SingleVideoItemViewController.h"
#import "UserDefaults.h"
#import "AppDelegate.h"

@interface MainTableViewController ()

@property (strong, nonatomic) NSArray *items;

@property (strong, nonatomic) NSArray *controllerIdentifiers;

@end

@implementation MainTableViewController

#pragma mark -
#pragma mark View Did Load/Unload

- (void)viewWillAppear:(BOOL)animated
{
    //强制旋转
    if (UIInterfaceOrientationIsLandscape([[UIApplication sharedApplication] statusBarOrientation])) {
        AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
        appDelegate.allowRotation = NO;
        [[UIDevice currentDevice] setValue:[NSNumber numberWithInteger: UIDeviceOrientationPortrait] forKey:@"orientation"];
        
    }
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
    
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
    
    [self setup];
}

- (void)setup
{
    self.title = NSLocalizedString(@"Title", nil);

    self.items = [NSArray arrayWithObjects:
                  NSLocalizedString(@"SingleVideo", @"单路视频"),
                  NSLocalizedString(@"MultiVideo", @"多路视频"),
                  NSLocalizedString(@"Doc", @"文档"),
                  NSLocalizedString(@"Chat", @"聊天"),
                  NSLocalizedString(@"Qa", @"问答"),
                  NSLocalizedString(@"Investigation", @"问卷调查"),
                  NSLocalizedString(@"Lottery", @"抽奖"),
                  NSLocalizedString(@"CheckIn", @"点名"),
                  NSLocalizedString(@"LocalPlayer", @"发布视频"),
                  NSLocalizedString(@"PublishDoc", @"文档发布"),
                  nil];
    self.controllerIdentifiers = [NSArray arrayWithObjects:@"SingleVideo", @"MultiVideo", @"Doc", @"Chat", @"Qa", @"Investigation", @"Lottery", @"Checkin", @"LocalPlayer", @"PublishDoc", nil];
}

#pragma mark -
#pragma mark System Default Code

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark -
#pragma mark Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
//#warning Potentially incomplete method implementation.
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
//#warning Incomplete method implementation.
    // Return the number of rows in the section.
    return self.items.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"cell" forIndexPath:indexPath];
    // Configure the cell...
    cell.textLabel.text = self.items[indexPath.row];
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    UIStoryboard *board = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
    
    BaseItemViewController *controller = [board instantiateViewControllerWithIdentifier:self.controllerIdentifiers[indexPath.row]];
    
    controller.title = self.items[indexPath.row];
    
    GSConnectInfo *connectInfo = [GSConnectInfo new];
    connectInfo.domain = self.domain;
    if ([self.serviceType isEqualToString:@"webcast"]) {
        connectInfo.serviceType = GSBroadcastServiceTypeWebcast;
    }
    else if ([self.serviceType isEqualToString:@"training"])
    {
        connectInfo.serviceType = GSBroadcastServiceTypeTraining;

    }
    else
    {
        UIAlertView *alert = [[UIAlertView alloc]initWithTitle:nil message:NSLocalizedString(@"WrongServiceType", @"服务类型填写错误") delegate:nil cancelButtonTitle:NSLocalizedString(@"OK", @"知道了") otherButtonTitles:nil, nil];
        [alert show];
    }
    
    
    connectInfo.loginName = self.loginName;
    connectInfo.loginPassword = self.loginPassword;
    connectInfo.roomNumber = self.roomNumber;
    connectInfo.nickName = self.nickName;
    connectInfo.watchPassword = self.watchPassword;
    connectInfo.thirdToken = self.token;
    
//    connectInfo.oldVersion = YES;
    


    
////    _connectInfo = [GSConnectInfo new];
//    connectInfo.domain = @"yueju.gensee.com";
//    connectInfo.serviceType = GSBroadcastServiceTypeTraining;
////    connectInfo.roomNumber = @"55043263";
//    connectInfo.webcastID = @"XBqudTFWFq";
//    connectInfo.nickName = @"Ostrish";
//    connectInfo.watchPassword = @"070695";
//    connectInfo.loginName = @"admin@dawen.com";
//    connectInfo.loginPassword = @"111111";
//    
    
//        connectInfo.domain = @"huiwei.gensee.com";
//        connectInfo.serviceType = GSBroadcastServiceTypeWebcast;
//        connectInfo.loginName = @"";
//        connectInfo.loginPassword = @"";
//        connectInfo.watchPassword = @"123456";
//        connectInfo.nickName = @"hello";
//        connectInfo.roomNumber = @"15058528";
//        connectInfo.customUserID = 1000000000+11033;

    
    // Training
//    GSConnectInfo *connectInfo = [GSConnectInfo new];
//    connectInfo.domain =@"wx.gensee.com";
//    connectInfo.serviceType = GSBroadcastServiceTypeTraining;
//    connectInfo.loginName = @"qwert@test.com";
//    connectInfo.loginPassword = @"111111";
//    connectInfo.roomNumber = @"29445005";
//    connectInfo.nickName = @"ios";
//    connectInfo.watchPassword = @"326766";
    
    
    // Webcast
//    GSConnectInfo *connectInfo = [GSConnectInfo new];
//    connectInfo.domain =@"demo.gensee.com";
//    connectInfo.serviceType = GSBroadcastServiceTypeWebcast;
//    connectInfo.loginName = @"qwert@test.com";
//    connectInfo.loginPassword = @"111111";
//    connectInfo.webcastID = @"64347d5122e846ccb3ad5757929bb1b2";
//    connectInfo.nickName = @"ios";
//    connectInfo.watchPassword = @"333333";
    
//    
////        GSConnectInfo *connectInfo = [GSConnectInfo new];
//        connectInfo.domain =@"maxtv.gensee.com";
//        connectInfo.serviceType = GSBroadcastServiceTypeTraining;
////        connectInfo.loginName = @"qwert@test.com";
////        connectInfo.loginPassword = @"111111";
////        connectInfo.webcastID = @"64347d5122e846ccb3ad5757929bb1b2";
//        connectInfo.roomNumber = @"27417238";
//        connectInfo.nickName = @"ios";
//        connectInfo.watchPassword = @"388809";
//    connectInfo.oldVersion = YES;
    
    [UserDefaults setDomain:self.domain];
    [UserDefaults setServiceType:self.serviceType];
    [UserDefaults setLoginName:self.loginPassword];
    [UserDefaults setLoginPassword:self.loginPassword];
    [UserDefaults setRoomNumber:self.roomNumber];
    [UserDefaults setWebcastID:self.webcastID];
    [UserDefaults setNickname:self.nickName];
    [UserDefaults setWatchPassword:self.watchPassword];
    [UserDefaults save];
    
    controller.connectInfo = connectInfo;
    [self.navigationController pushViewController:controller animated:YES];
    
}


/*
// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
*/

/*
// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        // Delete the row from the data source
        [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
    } else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }   
}
*/

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath {
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/



@end
