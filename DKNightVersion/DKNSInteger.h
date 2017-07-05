//
//  DKNSInteger.h
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/28.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef NSString DKThemeVersion;

typedef NSInteger (^DKNSIntegerPicker)(DKThemeVersion *themeVersion);

DKNSIntegerPicker DKNSIntegerPickerWithints(NSInteger normal, ...);

@interface DKNSInteger : NSObject

+ (DKNSIntegerPicker)DKNSIntegerPickerWithints:(NSArray<NSNumber *> *)ints;

@end
