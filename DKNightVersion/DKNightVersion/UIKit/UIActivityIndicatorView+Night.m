//
//  UIActivityIndicatorView+Night.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/28.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "UIActivityIndicatorView+Night.h"
#import "DKNightVersionManager.h"
#import <objc/runtime.h>
#import <objc/message.h>

@interface UIActivityIndicatorView()

@property (nonatomic, strong) NSMutableDictionary<NSString *, DKColorPicker> *pickers;

@end

@implementation UIActivityIndicatorView (Night)

- (DKNSIntegerPicker)dk_activityIndicatorViewStyle {
    return objc_getAssociatedObject(self, @selector(dk_activityIndicatorViewStyle));
}

- (void)dk_setActivityIndicatorViewStyle:(DKNSIntegerPicker)picker {
    objc_setAssociatedObject(self, @selector(dk_activityIndicatorViewStyle), picker, OBJC_ASSOCIATION_COPY_NONATOMIC);
    self.activityIndicatorViewStyle = picker(self.dk_manager.themeVersion);
    [self.pickers setValue:[picker copy] forKey:@"setActivityIndicatorViewStyle:"];
}

- (void)night_updateColor {
    [self.pickers enumerateKeysAndObjectsUsingBlock:^(NSString * _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
        if ([key isEqualToString:@"setActivityIndicatorViewStyle:"]) {
            DKNSIntegerPicker picker = (DKNSIntegerPicker)obj;
            NSInteger integer = picker(self.dk_manager.themeVersion);
            [self setActivityIndicatorViewStyle:integer];
        } else {
            SEL sel = NSSelectorFromString(key);
            DKColorPicker picker = (DKColorPicker)obj;
            UIColor *resultColor = picker(self.dk_manager.themeVersion);
            [UIView animateWithDuration:DKNightVersionAnimationDuration
                             animations:^{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
                                 [self performSelector:sel withObject:resultColor];
#pragma clang diagnostic pop
                             }];

        }
    }];
}

@end
