using System;
using System.Collections.Generic;
using TapTap.Bootstrap;
using TapTap.Common;
using XD.Cn.Common;

namespace XD.Cn.Account{
    public class XDAccountImpl{
        private XDAccountImpl(){
            EngineBridge.GetInstance()
                .Register(XDUnityBridge.ACCOUNT_SERVICE_NAME, XDUnityBridge.ACCOUNT_SERVICE_IMPL);
        }

        private readonly string XDG_ACCOUNT_SERVICE = "XDLoginService"; //注意要和iOS本地的桥接文件名一样！ 
        private static volatile XDAccountImpl _instance;
        private static readonly object Locker = new object();

        public static XDAccountImpl GetInstance(){
            lock (Locker){
                if (_instance == null){
                    _instance = new XDAccountImpl();
                }
            }

            return _instance;
        }

        public void Login(){
            var command = new Command(XDG_ACCOUNT_SERVICE,
                "login",
                true,
                null);
            EngineBridge.GetInstance().CallHandler(command, result => {
                XDTool.Log("Login 方法结果: " + result.ToJSON());
                if (XDTool.checkResultSuccess(result)){
                    var userWrapper = new XDUserWrapper(result.content);
                    if (userWrapper.error != null){
                        XDTool.Log("Login 登录失败");
                        return;
                    }
                    LoginSync();
                }
            });
        }

        public void LoginByType(string loginType){
            var command = new Command.Builder()
                .Service(XDG_ACCOUNT_SERVICE)
                .Method("loginType")
                .Args("loginType", loginType)
                .Callback(true)
                .CommandBuilder();

            EngineBridge.GetInstance().CallHandler(command, result => {
                XDTool.Log("LoginByType 方法结果: " + result.ToJSON());
                if (XDTool.checkResultSuccess(result)){
                    var userWrapper = new XDUserWrapper(result.content);
                    if (userWrapper.error != null){
                        XDTool.Log("Login 登录失败");
                        return;
                    }
                    LoginSync();
                }
            });
        }

        private void LoginSync(){ //需要登录成功才执行这个
            XDTool.Log("LoginSync 开始执行");
            var command = new Command(XDG_ACCOUNT_SERVICE, "loginSync", true, null);
            EngineBridge.GetInstance().CallHandler(command, (result => {
                try{
                    XDTool.Log("LoginSync 方法结果: " + result.ToJSON());
                    if (!XDTool.checkResultSuccess(result)){
                        XDTool.Log("LoginSync 解析失败: ");
                        return;
                    }

                    var contentDic = Json.Deserialize(result.content) as Dictionary<string, object>;
                    var token = SafeDictionary.GetValue<string>(contentDic, "sessionToken");
                    TDSUser.BecomeWithSessionToken(token);
                    StartUpAntiAddiction();
                }
                catch (Exception e){
                    XDTool.LogError("LoginSync 报错：" + e.Message);
                    Console.WriteLine(e);
                }
            }));
        }

        public void Logout(){
            var command = new Command(XDG_ACCOUNT_SERVICE, "logout", false, null);
            EngineBridge.GetInstance().CallHandler(command);
            TDSUser.Logout(); //退出LC
        }

        public void GetUser(Action<XDUser> callback, Action<XDError> errorCallback){
            var command = new Command(XDG_ACCOUNT_SERVICE, "getUser", true, null);
            EngineBridge.GetInstance().CallHandler(command, result => {
                XDTool.Log("GetUser 方法结果: " + result.ToJSON());
                if (!XDTool.checkResultSuccess(result)){
                    errorCallback(new XDError(result.code, result.message));
                    return;
                }

                XDUserWrapper userWrapper = new XDUserWrapper(result.content);
                if (userWrapper.error != null){
                    errorCallback(userWrapper.error);
                    return;
                }

                callback(userWrapper.user);
            });
        }

        public void OpenUserCenter(){
            XDTool.Log("执行： OpenUserCenter");
            var command = new Command(XDG_ACCOUNT_SERVICE, "openUserCenter", false, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        private void StartUpAntiAddiction(){
            XDTool.Log("执行： StartUpAntiAddiction");
            var command = new Command(XDG_ACCOUNT_SERVICE, "startUpAntiAddiction", false, null);
            EngineBridge.GetInstance().CallHandler(command);
        }
    }
}