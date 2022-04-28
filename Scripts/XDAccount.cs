using System;
using XD.Cn.Common;

namespace XD.Cn.Account{
    public class XDAccount{
        public static void Login(Action<XDUser> callback, Action<XDError> errorCallback){
            XDAccountImpl.GetInstance().Login(callback, errorCallback);
        }

        public static void LoginByType(LoginType loginType, Action<XDUser> callback, Action<XDError> errorCallback){
            XDAccountImpl.GetInstance().LoginByType(loginType, callback, errorCallback);
        }

        public static void Logout(){
            XDAccountImpl.GetInstance().Logout();
        }

        public static void GetUser(Action<XDUser> callback, Action<XDError> errorCallback){
            XDAccountImpl.GetInstance().GetUser(callback, errorCallback);
        }

        public static void OpenUserCenter(){
            XDAccountImpl.GetInstance().OpenUserCenter();
        }
        
        public static void AccountCancellation(){
            XDAccountImpl.GetInstance().AccountCancellation();
        }
    }
}