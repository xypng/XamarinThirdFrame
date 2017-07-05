//
//  UIBarItem+Night.m
//  DKNightVersionDemo
//
//  Created by XiaoYiPeng on 2017/6/20.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "UIBarItem+Night.h"
#import <objc/runtime.h>
#import <objc/message.h>

@interface UIBarItem()

@property (nonatomic, strong) NSMutableDictionary<NSString *, id> *pickers;

@end

@implementation UIBarItem (Night)

- (DKImagePicker)dk_imagePicker {
    return objc_getAssociatedObject(self, @selector(dk_imagePicker));
}

- (void)dk_setImagePicker:(DKImagePicker)picker {
    objc_setAssociatedObject(self, @selector(dk_imagePicker), picker, OBJC_ASSOCIATION_COPY_NONATOMIC);
    self.image = picker(self.dk_manager.themeVersion);
    [self.pickers setValue:[picker copy] forKey:@"setImage:"];
}

- (void)night_updateColor {
    [self.pickers enumerateKeysAndObjectsUsingBlock:^(NSString * _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
            SEL sel = NSSelectorFromString(key);
            DKImagePicker picker = (DKImagePicker)obj;
            UIImage *resultImage = picker(self.dk_manager.themeVersion);
            [UIView animateWithDuration:DKNightVersionAnimationDuration
                             animations:^{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
                                 [self performSelector:sel withObject:resultImage];
#pragma clang diagnostic pop
                             }];

    }];
}

@end
