//
//  DKAttributedString.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/15.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "DKAttributedString.h"
#import "DKNightVersionManager.h"
#import "DKColorTable.h"

@implementation DKAttributedString

DKAttributedStringPicker DKAttributedStringPickerWithAttributeds(NSAttributedString *normalAttributed,...) {
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSMutableArray<NSAttributedString *> *attributeds = [[NSMutableArray alloc] initWithCapacity:themes.count];
    [attributeds addObject:normalAttributed];
    NSUInteger num_args = themes.count - 1;
    va_list attributed_list;
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wvarargs"
    va_start(attributed_list, num_args);
#pragma clang diagnostic pop

    for (NSUInteger i = 0; i < num_args; i++) {
        NSAttributedString *attributed = va_arg(attributed_list, NSAttributedString *);
        [attributeds addObject:attributed];
    }
    va_end(attributed_list);

    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        return attributeds[index];
    };
}

+ (DKAttributedStringPicker)DKAttributedStringPickerWithAttributeds:(NSArray<NSAttributedString *> *)attributeds {
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSParameterAssert(attributeds.count == themes.count);
    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        if (index >= themes.count) {
            return attributeds[[themes indexOfObject:DKThemeVersionNormal]];
        }
        return attributeds[index];
    };
}

@end
