using System;
using XD.Cn.Common;

namespace XD.Cn.Account{
    public class XDAccount{
        public static void Login(){
            XDAccountImpl.GetInstance().Login();
        }
        
        public static void LoginByType(string loginType){
            XDAccountImpl.GetInstance().LoginByType(loginType);
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
    }
}