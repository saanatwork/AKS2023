using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.User;
using AKS.DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace AKS.BLL.Repository
{
    public class UserRepository : IUserRepository
    {
        UserEntity _UserEntity;
        string objPath = "AKS.BLL.Repository.UserRepository";
        public UserRepository()
        {
            _UserEntity = new UserEntity();
        }
        public LogInUserInfo LogIn(string UserName, string Password, ref string pMsg, ref bool result)
        {
            string HashedPwd = "";
            LogInUserInfo obj1= _UserEntity.GetUserInfo(UserName, ref pMsg,ref HashedPwd);
            if (obj1 != null) 
            {
                result=Crypto.VerifyHashedPassword(HashedPwd, Password);
                if (result) 
                {
                    setUser(obj1);
                }
            }
            return obj1;
        }
        public void SetLogInUser(LogInUserInfo user) 
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["LUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMonths(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            string json = JsonConvert.SerializeObject(user, Formatting.None);
            HttpContext.Current.Response.Cookies.Add(
                new HttpCookie("LUser", json)
                { Expires = DateTime.Now.AddDays(7) });
        }
        private void setUser(LogInUserInfo user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.None);
            //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //var json = serializer.Serialize(user);
            HttpContext.Current.Response.Cookies.Add(
                new HttpCookie("LUser", json)
                { Expires = DateTime.Now.AddDays(7) });
        }
        public LogInUserInfo getLoggedInUser()
        {
            LogInUserInfo user = new LogInUserInfo();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["LUser"];
            if (cookie != null)
            {
                user = JsonConvert.DeserializeObject<LogInUserInfo>(cookie.Value);
            }
            return user;
        }
        private void setUserExpire(int days)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["LUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(days);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public void LogOut()
        {
            //clearing cookies
            HttpCookie cookie = HttpContext.Current.Request.Cookies["LUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMonths(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public List<UserMenu> GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) 
        {
            return _UserEntity.GetUserMenu(UserID, ProfitCentreID, ref pMsg);
        }
        public List<UserForList> GetUserList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            return _UserEntity.GetUserList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public UserInfo GetUser(int UserID, ref string pMsg) 
        {
            return _UserEntity.GetUser(UserID,ref pMsg);
        }
        public bool SetUserInfo(MyUser data, ref string pMsg) 
        {
            return _UserEntity.SetUserInfo(data, ref pMsg);
        }
        public bool SetUser(UserInfoWithPwd data, ref string pMsg) 
        {
            data.HashedPassword = Crypto.HashPassword(data.HashedPassword);
            return _UserEntity.SetUser(data, ref pMsg);
        }
        public bool ChangePassword(string Contactno,string OldPassword,int UserID, string Password, ref string pMsg) 
        {
            string HashedPwd = "";
            _UserEntity.GetUserInfo(Contactno, ref pMsg, ref HashedPwd);
            if (Crypto.VerifyHashedPassword(HashedPwd, OldPassword))
            {
                return _UserEntity.ChangePassword(UserID, Crypto.HashPassword(Password), ref pMsg);
            }
            else 
            { pMsg = "Invalid Old Password"; return false; }
        }
        
    }
}
