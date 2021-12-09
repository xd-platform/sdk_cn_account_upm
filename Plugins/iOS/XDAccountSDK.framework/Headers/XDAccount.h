
#import <Foundation/Foundation.h>
#import <XDCommonSDK/XDGEntryType.h>

NS_ASSUME_NONNULL_BEGIN
@class XDUser;

/**
  Describes the call back to the TDSGlobalLoginManager
 @param result the result of the login request
 @param error error, if any.
 */
typedef void (^XDLoginManagerRequestCallback)(XDUser * _Nullable result, NSError * _Nullable error);

typedef void(^XDLoginSyncCallback)(NSDictionary * _Nullable result,NSError * _Nullable error);


@interface XDAccount : NSObject

// 不带防沉迷的登录
+ (void)login:(XDLoginManagerRequestCallback)handler;

// 不带防沉迷
+ (void)loginByType:(LoginEntryType)loginType loginHandler:(nonnull XDLoginManagerRequestCallback)handler;


#pragma mark ---TODO 新增方法
// 开启合规认证
+ (void)startUpAntiAddiction;

#pragma mark ---TODO 新增方法

/// Open login view  带合规
+ (void)loginWithPolicy;


#pragma mark ---TODO 新增方法
/**
 You can customize login buttons in your own ways,and call this methods to login an user. 带防沉迷
 Steps:
    1. use LoginEntryTypeDefault ,check if there was an user logged last time,you will get a result.
    2. if step 1 failed, show login buttons ,and call with corresponding type when user tapped.
 */
//+ (void)loginByType:(LoginEntryType)loginType loginHandler:(XDGLoginManagerRequestCallback)handler;

+ (void)loginWithPolicyByType:(LoginEntryType)loginType;

+ (void)loginSync:(XDLoginSyncCallback)handler;


/// Logout current user
+ (void)logout;

/// Get current user
+ (void)getUser:(XDLoginManagerRequestCallback)handler;

/// Open usercenter view
+ (void)openUserCenter;



/**强制微信网页端方式登录*/
+ (void)setWXWeb;
/**强制QQ网页端方式*/
+ (void)setQQWeb;

@end

NS_ASSUME_NONNULL_END
