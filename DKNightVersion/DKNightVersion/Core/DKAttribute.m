//
//  DKAttribute.m
//  ESports
//
//  Created by 时彬强 on 2017/5/5.
//  Copyright © 2017年 QQLS. All rights reserved.
//

#import "DKAttribute.h"
#import "DKNightVersionManager.h"
#import "DKColorTable.h"

@implementation DKAttribute

DKAttributePicker DKAttributePickerWithAttributes(NSDictionary *normal, ...) {
    
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSMutableArray<NSDictionary *> *attributes = [[NSMutableArray alloc] initWithCapacity:themes.count];
    [attributes addObject:normal];
    NSUInteger num_args = themes.count - 1;
    va_list colors_list;
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wvarargs"
    va_start(colors_list, num_args);
#pragma clang diagnostic pop
    
    for (NSUInteger i = 0; i < num_args; i++) {
        NSDictionary *attribute = va_arg(colors_list, NSDictionary *);
        [attributes addObject:attribute];
    }
    va_end(colors_list);
    
    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        return attributes[index];
    };
}

+ (DKAttributePicker)DKAttributePickerWithAttributes:(NSArray<NSDictionary *> *)attributes {
    NSArray<DKThemeVersion *> *themes = [DKColorTable sharedColorTable].themes;
    NSParameterAssert(attributes.count == themes.count);
    return ^(DKThemeVersion *themeVersion) {
        NSUInteger index = [themes indexOfObject:themeVersion];
        if (index >= themes.count) {
            return attributes[[themes indexOfObject:DKThemeVersionNormal]];
        }
        return attributes[index];
    };
}

@end
