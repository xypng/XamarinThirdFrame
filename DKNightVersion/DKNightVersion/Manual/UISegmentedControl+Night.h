//
//  UISegmentedControl+Night.h
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/22.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "DKNightVersion.h"

@interface UISegmentedControl (Night)

- (void)dk_setTitleTextAttributes:(DKAttributePicker)picker forState:(UIControlState)state;

@end
