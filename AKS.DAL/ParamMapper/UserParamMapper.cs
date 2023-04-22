using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ParamMapper
{
    public class UserParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.UserParamMapper";
        public SqlParameter[] MapParam_UserLogIn(string UserName, string HashedPassword, ref string pMsg) 
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                para[paracount++].Value = UserName;
                para[paracount] = new SqlParameter("@Password", SqlDbType.NVarChar);
                para[paracount++].Value = HashedPassword;
            }
            catch (Exception ex) 
            {
                pMsg = objPath+ ".MapParam_UserLogIn(string UserName, string HashedPassword, ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_GetUserInfo(string UserName, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[1];
            try
            {
                para[paracount] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                para[paracount++].Value = UserName;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_GetUserInfo(string UserName, ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) 
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = UserID;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = ProfitCentreID;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_GetUserMenu(int UserID, int ProfitCentreID, ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetUserInfo(MyUser data,ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[6];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.UserID;
                para[paracount] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                para[paracount++].Value = data.UserName;
                para[paracount] = new SqlParameter("@EmailID", SqlDbType.NVarChar);
                para[paracount++].Value = data.EmailID;
                para[paracount] = new SqlParameter("@ContactNo", SqlDbType.NVarChar);
                para[paracount++].Value = data.ContactNo;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.NVarChar,1);
                para[paracount++].Value = data.IsActive?"Y":"N";
                para[paracount] = new SqlParameter("@IsSuperUser", SqlDbType.NVarChar,1);
                para[paracount++].Value = data.IsSuperUser?"Y":"N";
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetUserInfo(MyUser data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetUser(UserInfoWithPwd data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {                
                para[paracount] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                para[paracount++].Value = data.UserName;
                para[paracount] = new SqlParameter("@EmailID", SqlDbType.NVarChar);
                para[paracount++].Value = data.EmailID;
                para[paracount] = new SqlParameter("@ContactNo", SqlDbType.NVarChar);
                para[paracount++].Value = data.ContactNo;
                para[paracount] = new SqlParameter("@Passwod", SqlDbType.NVarChar);
                para[paracount++].Value = data.HashedPassword;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetUser(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_ChangePassword(int UserID,string Password, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = UserID;
                para[paracount] = new SqlParameter("@Password", SqlDbType.NVarChar);
                para[paracount++].Value = Password;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_ChangePassword(...) " + ex.Message;
            }
            return para;
        }



    }
}
