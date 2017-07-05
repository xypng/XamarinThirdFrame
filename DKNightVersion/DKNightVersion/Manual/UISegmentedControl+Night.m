//
//  UISegmentedControl+Night.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/22.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "UISegmentedControl+Night.h"
#import <objc/runtime.h>
#import <objc/message.h>

@interface UISegmentedControl()

@property (nonatomic, strong) NSMutableDictionary<NSString *, id> *pickers;

@end

@implementation UISegmentedControl (Night)

- (void)dk_setTitleTextAttributes:(DKAttributePicker)picker forState:(UIControlState)state {
    [self setTitleTextAttributes:picker(self.dk_manager.themeVersion) forState:state];

    NSString *key = [NSString stringWithFormat:@"%@", @(state)];
    NSMutableDictionary *dictionary = [self.pickers valueForKey:key];
    if (!dictionary) {
        dictionary = [[NSMutableDictionary alloc] init];
    }
    [dictionary setValue:[picker copy] forKey:NSStringFromSelector(@selector(setTitleTextAttributes:forState:))];
    [self.pickers setValue:dictionary forKey:key];
}

- (void)night_updateColor {

    [self.pickers enumerateKeysAndObjectsUsingBlock:^(NSString * _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
        if ([obj isKindOfClass:[NSDictionary class]]) {
            NSDictionary<NSString *, DKAttributePicker> *dictionary = (NSDictionary *)obj;
            [dictionary enumerateKeysAndObjectsUsingBlock:^(NSString * _Nonnull selector, DKAttributePicker  _Nonnull picker, BOOL * _Nonnull stop) {
                UIControlState state = [key integerValue];
                if ([selector isEqualToString:NSStringFromSelector(@selector(setTitleTextAttributes:forState:))]) {
                    NSDictionary *attribute = picker(self.dk_manager.themeVersion);
                    [self setTitleTextAttributes:attribute forState:state];
                }
            }];
        } else {
            SEL sel = NSSelectorFromString(key);
            DKAttributePicker picker = (DKAttributePicker)obj;
            NSDictionary *attribute = picker(self.dk_manager.themeVersion);
            [UIView animateWithDuration:DKNightVersionAnimationDuration
                             animations:^{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
                                 [self performSelector:sel withObject:attribute];
#pragma clang diagnostic pop
                             }];

        }
    }];
}

@end
