//
//  NSAttributedStringYYText.m
//  YYImageInLabel
//
//  Created by XiaoYiPeng on 2017/6/9.
//  Copyright © 2017年 XiaoYiPeng. All rights reserved.
//

#import "NSAttributedStringYYText.h"
#import "NSAttributedString+YYText.h"

@implementation NSAttributedStringYYText

+ (NSMutableAttributedString *)attachmentStringWithContent:(nullable id)content
                                               contentMode:(UIViewContentMode)contentMode
                                            attachmentSize:(CGSize)attachmentSize
                                               alignToFont:(UIFont *)font
                                                 alignment:(YYTextVerticalAlignment)alignment
{
    return [NSAttributedString attachmentStringWithContent:content
                                               contentMode:contentMode
                                            attachmentSize:attachmentSize
                                               alignToFont:font
                                                 alignment:alignment];
}

@end
