using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IUserRepository
    {
        LogInUserInfo LogIn(string UserName, string Password, ref string pMsg, ref bool result);
        LogInUserInfo getLoggedInUser();
        void LogOut();
        void SetLogInUser(LogInUserInfo user);
        List<UserMenu> GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg);
        List<UserForList> GetUserList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        UserInfo GetUser(int UserID, ref string pMsg);
        bool SetUserInfo(MyUser data, ref string pMsg);
        



    }
}
