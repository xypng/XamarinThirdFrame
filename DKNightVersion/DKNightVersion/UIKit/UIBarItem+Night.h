//
//  UIBarItem+Night.h
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/20.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NSObject+Night.h"

@interface UIBarItem (Night)

@property (nullable, nonatomic, copy, setter = dk_setImagePicker:) DKImagePicker dk_imagePicker;

@end
