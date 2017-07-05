//
//  UIActivityIndicatorView+Night.h
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/28.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NSObject+Night.h"

@interface UIActivityIndicatorView (Night)

@property(nonatomic, setter=dk_setActivityIndicatorViewStyle:) DKNSIntegerPicker dk_activityIndicatorViewStyle;

@end
