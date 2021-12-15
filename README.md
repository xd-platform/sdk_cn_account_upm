# XD-Cn Account

## 1.在Packages/manifest.json中加入如下引用
```
"com.xd.cn.account": "https://github.com/xd-platform/sdk_cn_account_upm.git#{version}",
```
## 2.接口使用

#### 绑定回调
使用sdk前需先绑定回调
```
 XDCommon.SetBridgeCallBack((type, result, errorMsg) => {
                logText = "type:= " + type + " result: " + result;
            });
```

#### 初始化
```
//orientation: 0横屏，1竖屏
XDCommon.InitSDK(clientId, orientation);
```

#### 是否初始化
```
 XDCommon.IsInitialized(b => { 
  });
```

#### 获取版本号
```
 XDCommon.GetSDKVersionName((result) => { 
 });
```

#### 弹框登录
```
 XDAccount.Login();
```

#### 单点登录
```
  //type: "TAPTAP" or "GUEST"
  XDAccount.LoginByType(type);
```

#### 退出登录
```
XDAccount.Logout();
```

#### 获取用户
```
     XDAccount.GetUser(user => { 
     }, error => { 
     });
        
```

#### 打开用户中心
```
XDAccount.OpenUserCenter();
```

#### 客服Report
```
XDCommon.Report("serverId", "roleId", "roleName");
```

#### EnterGame
```
XDCommon.EnterGame();
```


#### LeaveGame
```
XDCommon.LeaveGame();
```


#### 获取AgeRangeType
```
 XDCommon.GetAntiAddictionAgeRange((type) => {
               
            });
```
