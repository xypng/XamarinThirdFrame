//
//  MainTableViewController.h
//  iOSDemo
//
//  Created by Gaojin Hsu on 3/16/15.
//  Copyright (c) 2015 gensee. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MainTableViewController : UITableViewController

@property (strong, nonatomic)NSString *domain;

@property (strong, nonatomic)NSString *serviceType;

@property (strong, nonatomic)NSString *loginName;

@property (strong, nonatomic)NSString *loginPassword;

@property (strong, nonatomic)NSString *webcastID;

@property (strong, nonatomic)NSString *roomNumber;

@property (strong, nonatomic)NSString *nickName;

@property (strong, nonatomic)NSString *watchPassword;

@property (strong, nonatomic) NSString *token;


@end
