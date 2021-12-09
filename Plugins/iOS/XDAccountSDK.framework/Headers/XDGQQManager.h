//
//  XDGQQManager.h
//  XDGAccountSDK
//
//  Created by jessy on 2021/11/9.
//

#import <Foundation/Foundation.h>
#import <TencentOpenAPI/TencentOAuth.h>



NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,XDGQQManagerCode) {
    XDGQQLoginSuccess          = 0,
    XDGQQLoginCancle           = 1,
    XDGQQLoginFail             = 2,  
};

typedef void(^QQSendAuthCallBack)(NSString *accessToken, NSString *openId,XDGQQManagerCode code);

@interface XDGQQManager : NSObject<TencentSessionDelegate,TCAPIRequestDelegate,TencentLoginDelegate>

@property (nonatomic, strong) TencentOAuth *oauth;

@property (nonatomic, copy)QQSendAuthCallBack QQCallBack;

@property (nonatomic, assign)BOOL QQWeb;

+ (XDGQQManager *)sharedInstance;

+ (XDGQQManager *)initWithAppid:(NSString *)appid universalLink:(NSString *)universalLink;

- (void)tencentDidLogin;
- (void)tencentDidNotLogin:(BOOL)cancelled;
- (void)tencentDidNotNetWork;

@end

NS_ASSUME_NONNULL_END
