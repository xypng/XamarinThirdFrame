//
//  NSAttributedStringYYText.h
//  YYImageInLabel
//
//  Created by XiaoYiPeng on 2017/6/9.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "YYTextAttribute.h"

@interface NSAttributedStringYYText : NSObject

+ (NSMutableAttributedString *)attachmentStringWithContent:(nullable id)content
                                               contentMode:(UIViewContentMode)contentMode
                                            attachmentSize:(CGSize)attachmentSize
                                               alignToFont:(UIFont *)font
                                                 alignment:(YYTextVerticalAlignment)alignment;

@end
