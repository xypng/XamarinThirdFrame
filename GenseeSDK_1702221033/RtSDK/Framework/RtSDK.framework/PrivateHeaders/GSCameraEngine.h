//
//  GSCameraEngine.h
//  RtSDK
//
//  Created by apple on 14-6-12.
//  Copyright (c) 2014年 gensee. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
#import "H264HwEncoderImpl.h"
#import "GSBroadcastManager.h"

@class GSVideoRender;

@interface GSCameraEngine : NSObject
@property(nonatomic,strong)AVCaptureSession             *mySession;
@property(nonatomic,strong)AVCaptureVideoDataOutput     *myVideoOutput;;
@property(nonatomic,strong)AVCaptureConnection          *myVideoConnect;
@property(nonatomic, assign)BOOL landscape;
@property(nonatomic, strong) H264HwEncoderImpl *h264Encoder;
@property (nonatomic, strong)  NSFileHandle *fileHandle;
@property (nonnull, strong)GSBroadcastManager *manager;

- (void)stopVideoCapture;
- (int)numberOfCaptureDevices;
- (int)StartCaptureVideo:(NSString *)szUniName width:(int)width height:(int)height fps:(int)fps vSink:(GSVideoRender*)sink;
- (void)setCamera:(NSString *)szUniName width:(int)width height:(int)height fps:(int)fps vSink:(GSVideoRender*)sink;
- (void)startCameraing;
#ifdef BeautyFace
- (void)beautifyFace:(BOOL)beaytify;
#endif
- (void)rotateCamera;
- (void)onApplicationDidBecomeActive;
+ (GSCameraEngine*)shareInstance;

- (BOOL)isBackFacingCameraPresent;

@property(readwrite, nonatomic) UIInterfaceOrientation outputImageOrientation;


@end
