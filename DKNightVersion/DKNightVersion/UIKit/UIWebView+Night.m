//
//  UIWebView+Night.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/21.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "UIWebView+Night.h"
#import <objc/runtime.h>
#import <objc/message.h>

@interface UIWebView()

@property (nonatomic, strong) NSMutableDictionary<NSString *, id> *pickers;

@end

@implementation UIWebView (Night)

- (NSURLRequest *)dk_request {
    return objc_getAssociatedObject(self, @selector(dk_request));
}

- (void)dk_loadRequest:(NSURLRequest *)request {
    objc_setAssociatedObject(self, @selector(dk_request), request, OBJC_ASSOCIATION_COPY_NONATOMIC);
    [self loadRequest:request];
    [self.pickers setValue:[request copy] forKey:@"loadRequest:"];
}

- (void)night_updateColor {
    [self.pickers enumerateKeysAndObjectsUsingBlock:^(NSString * _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
        if ([key isEqualToString:NSStringFromSelector(@selector(loadRequest:))]) {
            SEL sel = NSSelectorFromString(key);
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
            [self performSelector:sel withObject:obj];
#pragma clang diagnostic pop
        }
        else
        {
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
