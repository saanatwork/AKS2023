using AKS.BOL.User;
using AKS.DAL.DataSync;
using AKS.DAL.ObjectMapper;
using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.Entities
{
    public class UserEntity
    {
        DataSet ds;
        DataTable dt;
        UserDataSync _UserDataSync;
        UserObjectMapper _UserObjectMapper;
        DBResponseMapper _DBResponseMapper;
        string objPath = "AKS.DAL.Entities.UserEntity";
        public UserEntity()
        {
            _UserDataSync = new UserDataSync();
            _UserObjectMapper = new UserObjectMapper();
            _DBResponseMapper = new DBResponseMapper();
        }
        public UserRBAC UserLogIn(string UserName, string HashedPassword, ref string pMsg) 
        {
            UserRBAC result = new UserRBAC();
            try
            {
                List<RBACRaw> rbaclist = new List<RBACRaw>();
                List<PCRBAC> pcrbaclist = new List<PCRBAC>();
                ds = _UserDataSync.UserLogIn(UserName, HashedPassword, ref pMsg);
                if (ds != null)
                {
                    DataTable userDt = null; DataTable rbacDt = null;
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0) { userDt = ds.Tables[0]; }
                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0) { rbacDt = ds.Tables[1]; }
                    if (userDt != null && userDt.Rows.Count > 0)
                    {
                        result.IsLogInSuccess = true;
                        result.userinfo = _UserObjectMapper.Map_UserInfo(userDt.Rows[0], ref pMsg);
                    }
                    if (rbacDt != null && rbacDt.Rows.Count > 0)
                    {
                        result.IsRBACFound = true;
                        for (int i = 0; i < rbacDt.Rows.Count; i++)
                        {
                            rbaclist.Add(_UserObjectMapper.Map_RBACRaw(rbacDt.Rows[i], ref pMsg));
                        }
                        if (rbaclist != null)
                        {
                            var objlist = rbaclist.Select(o => new { o.ProfitCentreID, o.ProfitCentreAddress, o.ProfitCentreDescription }).Distinct().ToList();
                            foreach (var item in objlist)
                            {
                                PCRBAC obj = new PCRBAC();
                                obj.PCID = item.ProfitCentreID;
                                obj.PCAddress = item.ProfitCentreAddress;
                                obj.PCDesc = item.ProfitCentreDescription;
                                var rbacobjlist = rbaclist.Where(o => o.ProfitCentreID == item.ProfitCentreID).ToList();
                                List<RBACMenu> menulist = new List<RBACMenu>();
                                foreach (var item1 in rbacobjlist)
                                {
                                    RBACMenu menu = new RBACMenu();
                                    menu.MenuName = item1.MenuName;
                                    menu.OptionName = item1.OptionName;
                                    menu.ControllerName = item1.EcodeControllerName;
                                    menu.ActionName = item1.EcodeViewName;
                                    menu.URL = item1.EcodeUrl;
                                    menulist.Add(menu);
                                }
                                obj.RbacMenu = menulist;
                                pcrbaclist.Add(obj);
                            }
                            result.pcrbac = pcrbaclist;
                        }
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".UserLogIn(string UserName, string HashedPassword, ref string pMsg) " + ex.Message; }
            return result;
        }
        public LogInUserInfo GetUserInfo(string UserName, ref string pMsg,ref string HashedPwd) 
        {
            LogInUserInfo result = new LogInUserInfo();
            try
            {
                ds = _UserDataSync.GetUserInfo(UserName, ref pMsg);
                if (ds != null)
                {
                    DataTable userDt = null; DataTable rbacDt = null;
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0) { userDt = ds.Tables[0]; }
                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0) { rbacDt = ds.Tables[1]; }
                    if (userDt != null && userDt.Rows.Count > 0)
                    {                        
                        result.user = _UserObjectMapper.Map_UserInfoWithPwd(userDt.Rows[0], ref pMsg, ref HashedPwd); 
                    }
                    if (rbacDt != null && rbacDt.Rows.Count > 0)
                    {
                        List<ProfitCentre> pclist = new List<ProfitCentre>();
                        for (int i = 0; i < rbacDt.Rows.Count; i++)
                        {
                            pclist.Add(_UserObjectMapper.Map_ProfitCentre(rbacDt.Rows[i], ref pMsg));
                        }
                        result.userpcs = pclist;
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserInfo(string UserName, ref string pMsg) " + ex.Message; }
            return result;
        }
        public List<UserMenu> GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) 
        {
            List<UserMenu> result = new List<UserMenu>();
            try
            {
                dt = _UserDataSync.GetUserMenu(UserID, ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_UserObjectMapper.Map_UserMenu(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) " + ex.Message; }
            return result;
        }
        public List<UserForList> GetUserList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg) 
        {
            List<UserForList> result = new List<UserForList>();
            try
            {
                dt = _UserDataSync.GetUserList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_UserObjectMapper.Map_UserForList(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserList(...) " + ex.Message; }
            return result;
        }
        public UserInfo GetUser(int UserID, ref string pMsg)
        {
            UserInfo result = new UserInfo();
            try
            {
                dt = _UserDataSync.GetUser(UserID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = _UserObjectMapper.Map_UserInfoForList(dt.Rows[0], ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUser(int UserID, ref string pMsg) " + ex.Message; }
            return result;
        }
        public bool SetUserInfo(MyUser data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_UserDataSync.SetUserInfo(data, ref pMsg), ref pMsg, ref result);
            return result;
        }

    }
}
