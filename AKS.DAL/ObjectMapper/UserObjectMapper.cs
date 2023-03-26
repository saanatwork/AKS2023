using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ObjectMapper
{    
    public class UserObjectMapper
    {
        string objPath = "AKS.DAL.ObjectMapper.UserObjectMapper";
        public UserInfo Map_UserInfoWithPwd(DataRow dr, ref string pMsg,ref string HashedPwd)
        {
            UserInfo result = new UserInfo();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.UserID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["FullName"]))
                        result.UserName = dr["FullName"].ToString();
                    if (!DBNull.Value.Equals(dr["EmailID"]))
                        result.EmailID = dr["EmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["ContactNo"]))
                        result.ContactNo = dr["ContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = dr["IsActive"].ToString().ToUpper() == "Y" ? true : false;
                    if (!DBNull.Value.Equals(dr["IsSuperUser"]))
                        result.IsSuperUser = dr["IsSuperUser"].ToString().ToUpper() == "Y" ? true : false;
                    if (!DBNull.Value.Equals(dr["ProfilePicture"]))
                        result.ProfilePicture = dr["ProfilePicture"].ToString();
                    if (!DBNull.Value.Equals(dr["Password"]))
                        HashedPwd = dr["Password"].ToString();
                    if (!DBNull.Value.Equals(dr["NoOfProfitCentres"]))
                        result.NoOfProfitCentres = int.Parse(dr["NoOfProfitCentres"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_UserInfoWithPwd(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public ProfitCentre Map_ProfitCentre(DataRow dr, ref string pMsg)
        {
            ProfitCentre result = new ProfitCentre();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.PCID = int.Parse(dr["ProfitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDescription"]))
                        result.PCDesc = dr["ProfitCentreDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["ProfitCentreAddress"]))
                        result.PCAddress = dr["ProfitCentreAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive =bool.Parse(dr["IsActive"].ToString());                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_ProfitCentre(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public UserInfo Map_UserInfo(DataRow dr,ref string pMsg) 
        {
            UserInfo result = new UserInfo();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.UserID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["FullName"]))
                        result.UserName =dr["FullName"].ToString();
                    if (!DBNull.Value.Equals(dr["EmailID"]))
                        result.EmailID = dr["EmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["ContactNo"]))
                        result.ContactNo = dr["ContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = dr["IsActive"].ToString().ToUpper()=="Y"?true:false;
                    if (!DBNull.Value.Equals(dr["IsSuperUser"]))
                        result.IsSuperUser = dr["IsSuperUser"].ToString().ToUpper() == "Y" ? true : false;
                    if (!DBNull.Value.Equals(dr["ProfilePicture"]))
                        result.ProfilePicture = dr["ProfilePicture"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_UserInfo(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public RBACRaw Map_RBACRaw(DataRow dr, ref string pMsg)
        {
            RBACRaw result = new RBACRaw();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["ProfitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDescription"]))
                        result.ProfitCentreDescription = dr["ProfitCentreDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["ProfitCentreAddress"]))
                        result.ProfitCentreAddress = dr["ProfitCentreAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["MenuName"]))
                        result.MenuName = dr["MenuName"].ToString();                    
                    if (!DBNull.Value.Equals(dr["OptionName"]))
                        result.OptionName = dr["OptionName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeControllerName"]))
                        result.EcodeControllerName = dr["EcodeControllerName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeViewName"]))
                        result.EcodeViewName = dr["EcodeViewName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeUrl"]))
                        result.EcodeUrl = dr["EcodeUrl"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_RBACRaw(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public UserMenu Map_UserMenu(DataRow dr, ref string pMsg)
        {
            UserMenu result = new UserMenu();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["MenuName"]))
                        result.MenuName = dr["MenuName"].ToString();
                    if (!DBNull.Value.Equals(dr["OptionName"]))
                        result.OptionName = dr["OptionName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeControllerName"]))
                        result.ControllerName = dr["EcodeControllerName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeViewName"]))
                        result.ActionName = dr["EcodeViewName"].ToString();
                    if (!DBNull.Value.Equals(dr["EcodeUrl"]))
                        result.URL = dr["EcodeUrl"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_UserMenu(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public UserForList Map_UserForList(DataRow dr, ref string pMsg) 
        {
            UserForList result = new UserForList();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["RowNum"]))
                        result.RowNum = int.Parse(dr["RowNum"].ToString());
                    if (!DBNull.Value.Equals(dr["TotalCount"]))
                        result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                    if (!DBNull.Value.Equals(dr["TotalRecords"]))
                        result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.ID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["FullName"]))
                        result.FullName = dr["FullName"].ToString();
                    if (!DBNull.Value.Equals(dr["EmailID"]))
                        result.EmailID = dr["EmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["ContactNo"]))
                        result.ContactNo = dr["ContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = dr["IsActive"].ToString().ToUpper();
                    if (!DBNull.Value.Equals(dr["IsSuperUser"]))
                        result.IsSuperUser = dr["IsSuperUser"].ToString().ToUpper();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_UserForList(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public UserInfo Map_UserInfoForList(DataRow dr, ref string pMsg)
        {
            UserInfo result = new UserInfo();
            try
            {
                if (dr != null)
                {                    
                    if (!DBNull.Value.Equals(dr["UserID"]))
                        result.UserID = int.Parse(dr["UserID"].ToString());
                    if (!DBNull.Value.Equals(dr["UserName"]))
                        result.UserName = dr["UserName"].ToString();
                    if (!DBNull.Value.Equals(dr["EmailID"]))
                        result.EmailID = dr["EmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["ContactNo"]))
                        result.ContactNo = dr["ContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = dr["IsActive"].ToString().ToUpper() == "Y" ? true : false;
                    if (!DBNull.Value.Equals(dr["IsSuperUser"]))
                        result.IsSuperUser = dr["IsSuperUser"].ToString().ToUpper() == "Y" ? true : false;
                    if (!DBNull.Value.Equals(dr["ProfilePicture"]))
                        result.ProfilePicture = dr["ProfilePicture"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_UserInfoForList(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }


    }
}
