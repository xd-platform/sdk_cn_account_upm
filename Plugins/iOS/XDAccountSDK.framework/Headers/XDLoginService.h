//
//  TDSGlobalSDKLoginService.h
//  XDGAccountSDK
//
//  Created by JiangJiahao on 2020/11/23.
//

#import <Foundation/Foundation.h>
#import <XDAccountSDK/XDAccount.h>
#import <XDCommonSDK/XDUser.h>
#import <XDCommonSDK/XDAccessToken.h>
#import <TDSGlobalSDKCommonKit/NSDictionary+TDSGlobalJson.h>

NS_ASSUME_NONNULL_BEGIN

@interface XDLoginService : NSObject

+ (void)login:(void (^)(NSString *result))callback;

+ (void)loginType:(NSString *)loginType
   bridgeCallback:(void (^)(NSString * _Nonnull))callback;

+ (void)startUpAntiAddiction;

//+ (void)addUserStatusChangeCallback:(void(^)(NSString *result))callback;

+ (void)getUser:(void (^)(NSString *result))callback;

+ (void)openUserCenter;

+ (void)logout;

// TDS authentication
+ (void)loginSync:(void(^)(NSString *result))callback;

// 账户注销
+ (void)accountCancellation;

//暴露给UE用
+ (NSString *)bridgeUserCallback:(XDUser *)user error:(NSError *)error;

@end

NS_ASSUME_NONNULL_END
