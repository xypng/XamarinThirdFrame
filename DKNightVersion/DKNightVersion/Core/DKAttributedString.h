//
//  DKAttributedString.h
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/15.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef NSString DKThemeVersion;

typedef NSAttributedString *(^DKAttributedStringPicker)(DKThemeVersion *themeVersion);

DKAttributedStringPicker DKAttributedStringPickerWithAttributeds(NSAttributedString *normalAttributed,...);

@interface DKAttributedString : NSObject

+ (DKAttributedStringPicker)DKAttributedStringPickerWithAttributeds:(NSArray<NSAttributedString *> *)attributeds;

@end
