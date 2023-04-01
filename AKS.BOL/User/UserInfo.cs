using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.User
{
    public class MyUser 
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuperUser { get; set; }
    }
    public class UserInfo : MyUser
    {        
        public string ProfilePicture { get; set; }
        public int NoOfProfitCentres { get; set; }
    }
    public class UserInfoWithPwd : UserInfo
    {
        public string HashedPassword { get; set; }
    }
    public class LogInUserInfo 
    {
        public UserInfo user { get; set; }
        public List<ProfitCentre> userpcs { get; set; }
        public int LogInProfitCentreID { get; set; }
        public int MyProperty { get; set; }
    }
    public class UserInfoAjaxRapper
    {
        public List<MyUser> UserList { get; set; }
    }
}
