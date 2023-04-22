using AKS.BOL.User;
using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.DataSync
{
    public class UserDataSync
    {
        UserParamMapper _UserParamMapper;
        CommonParamMapper _CommonParamMapper;
        string objPath = "AKS.DAL.DataSync.UserDataSync";
        public UserDataSync()
        {
            _UserParamMapper = new UserParamMapper();
            _CommonParamMapper = new CommonParamMapper();
        }
        public DataSet UserLogIn(string UserName,string HashedPassword, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[UserLogIn]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_UserParamMapper.MapParam_UserLogIn(UserName, HashedPassword,ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath+ ".UserLogIn(string UserName,string HashedPassword, ref string pMsg) " + ex.Message; return null; }
        }
        public DataSet GetUserInfo(string UserName, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[GetUserInfo]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_UserParamMapper.MapParam_GetUserInfo(UserName, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserInfo(string UserName,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) 
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[GetUserMenu]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_UserParamMapper.MapParam_GetUserMenu(UserID, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetUserList(int DisplayLength,int DisplayStart, int SortColumn,
            string SortDirection,string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[USR].[GetUserList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserList(...) " + ex.Message; return null; }
        }
        public DataTable GetUser(int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [USR].[GetUser]("+UserID+")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUser(int UserID, ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable SetUserInfo(MyUser data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[USR].[SetUserInfo]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_UserParamMapper.MapParam_SetUserInfo(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetUserInfo(MyUser data, ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable SetUser(UserInfoWithPwd data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[USR].[SetUser]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_UserParamMapper.MapParam_SetUser(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetUser(UserInfoWithPwd data, ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable ChangePassword(int UserID, string Password, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[USR].[ChangePassword]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_UserParamMapper.MapParam_ChangePassword(UserID, Password, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".ChangePassword(...) " + ex.Message; return null; }
        }





    }
}
