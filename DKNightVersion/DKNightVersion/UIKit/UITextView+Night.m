//
//  UITextView+Night.m
//  UITextView+Night
//
//  Copyright (c) 2015 Draveness. All rights reserved.
//
//  These files are generated by ruby script, if you want to modify code
//  in this file, you are supposed to update the ruby code, run it and
//  test it. And finally open a pull request.

#import "UITextView+Night.h"
#import "DKNightVersionManager.h"
#import <objc/runtime.h>

@interface UITextView ()

@property (nonatomic, strong) NSMutableDictionary<NSString *, DKColorPicker> *pickers;

@end

@implementation UITextView (Night)


- (DKColorPicker)dk_textColorPicker {
    return objc_getAssociatedObject(self, @selector(dk_textColorPicker));
}

- (void)dk_setTextColorPicker:(DKColorPicker)picker {
    objc_setAssociatedObject(self, @selector(dk_textColorPicker), picker, OBJC_ASSOCIATION_COPY_NONATOMIC);
    self.textColor = picker(self.dk_manager.themeVersion);
    [self.pickers setValue:[picker copy] forKey:@"setTextColor:"];
}

- (DKAttributedStringPicker)dk_attributedTextPicker {
    return objc_getAssociatedObject(self, @selector(dk_attributedTextPicker));
}

- (void)dk_setAttributedTextPicker:(DKAttributedStringPicker)picker {
    objc_setAssociatedObject(self, @selector(dk_attributedTextPicker), picker, OBJC_ASSOCIATION_COPY_NONATOMIC);
    self.attributedText = picker(self.dk_manager.themeVersion);
    [self.pickers setValue:[picker copy] forKey:@"setAttributedText:"];
}


@end
