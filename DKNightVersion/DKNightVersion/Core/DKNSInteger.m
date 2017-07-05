//
//  DKNSInteger.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/28.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "DKNSInteger.h"
#import "DKNightVersionManager.h"
#import "DKColorTable.h"

DKNSIntegerPicker DKNSIntegerPickerWithints(NSInteger normal, ...) {
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSMutableArray<NSNumber *> *ints = [[NSMutableArray alloc] initWithCapacity:themes.count];
    [ints addObject:@(normal)];
    NSUInteger num_args = themes.count - 1;
    va_list args;
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wvarargs"
    va_start(args, num_args);
#pragma clang diagnostic pop
    for (NSUInteger i = 0; i < num_args; i++) {
        double alpha = va_arg(args, int);
        [ints addObject:@(alpha)];
    }
    va_end(args);

    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        return (NSInteger)[ints[index] integerValue];
    };
}

@implementation DKNSInteger

+ (DKNSIntegerPicker)DKNSIntegerPickerWithints:(NSArray<NSNumber *> *)ints {
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSParameterAssert(ints.count == themes.count);
    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        if (index >= themes.count) {
            return (NSInteger)[ints[[themes indexOfObject:DKThemeVersionNormal]] integerValue];
        }
        return (NSInteger)[ints[index] integerValue];
    };
}

@end
