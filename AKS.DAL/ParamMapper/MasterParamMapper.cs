using AKS.BOL.Master;
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
    public class MasterParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.MasterParamMapper";
        public SqlParameter[] MapParam_SetProfitCentre(ProfitCentre data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[7];
            try
            {
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.PCID;
                para[paracount] = new SqlParameter("@ProfitCentreDescription", SqlDbType.NVarChar,50);
                para[paracount++].Value = data.PCDesc;
                para[paracount] = new SqlParameter("@ProfitCentreAddress", SqlDbType.NVarChar);
                para[paracount++].Value = data.PCAddress;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
                para[paracount] = new SqlParameter("@MakingCharges", SqlDbType.Int);
                para[paracount++].Value = data.MakingCharges;
                para[paracount] = new SqlParameter("@GLocation", SqlDbType.NVarChar,50);
                para[paracount++].Value = data.GLocation;
                para[paracount] = new SqlParameter("@DiamondDiscount", SqlDbType.Decimal);
                para[paracount++].Value = data.DiamondDiscount;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetProfitCentre(ProfitCentre data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetCategory(Category data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@CategoryCode", SqlDbType.NVarChar,5);
                para[paracount++].Value = data.CategoryCode;
                para[paracount] = new SqlParameter("@CategoryLongText", SqlDbType.NVarChar);
                para[paracount++].Value = data.CategoryLongText;
                para[paracount] = new SqlParameter("@HSNCode", SqlDbType.NVarChar,10);
                para[paracount++].Value = data.HSNCode;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetCategory(Category data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetVariant(Variant data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[7];
            try
            {
                para[paracount] = new SqlParameter("@ID", SqlDbType.Int);
                para[paracount++].Value = data.ID;
                para[paracount] = new SqlParameter("@CatID", SqlDbType.Int);
                para[paracount++].Value = data.VariantCatID;
                para[paracount] = new SqlParameter("@ShortText", SqlDbType.NVarChar, 50);
                para[paracount++].Value = data.ShortText;
                para[paracount] = new SqlParameter("@Purity", SqlDbType.NVarChar,10);
                para[paracount++].Value = data.Purity;
                para[paracount] = new SqlParameter("@UOM", SqlDbType.NVarChar, 15);
                para[paracount++].Value = data.UOM;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
                para[paracount] = new SqlParameter("@RatePerUnit", SqlDbType.Int);
                para[paracount++].Value = data.RatePerUnit;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetVariant(Variant data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_RemoveVariant(int VariantID, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[1];
            try
            {
                para[paracount] = new SqlParameter("@ID", SqlDbType.Int);
                para[paracount++].Value = VariantID;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_RemoveVariant(int VariantID,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetParty(Party data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[10];
            try
            {
                para[paracount] = new SqlParameter("@PartyCode", SqlDbType.Int);
                para[paracount++].Value = data.PartyCode;
                para[paracount] = new SqlParameter("@PartyName", SqlDbType.NVarChar,150);
                para[paracount++].Value = data.PartyName;
                para[paracount] = new SqlParameter("@PartyAddress", SqlDbType.NVarChar);
                para[paracount++].Value = data.PartyAddress;
                para[paracount] = new SqlParameter("@GSTIN", SqlDbType.NVarChar, 25);
                para[paracount++].Value = data.GSTIN;
                para[paracount] = new SqlParameter("@PartyContactNo", SqlDbType.NChar, 10);
                para[paracount++].Value = data.ContactNo;
                para[paracount] = new SqlParameter("@PartyEmailID", SqlDbType.NVarChar,150);
                para[paracount++].Value = data.EmailID;
                para[paracount] = new SqlParameter("@IsVendor", SqlDbType.Bit);
                para[paracount++].Value = data.IsVendor;
                para[paracount] = new SqlParameter("@IsCustomer", SqlDbType.Bit);
                para[paracount++].Value = data.IsCustomer;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
                para[paracount] = new SqlParameter("@OtherContactNo", SqlDbType.NVarChar);
                para[paracount++].Value = data.OtherContactNo;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetParty(Party data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_RemoveParty(int PartyCode, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[1];
            try
            {
                para[paracount] = new SqlParameter("@PartyCode", SqlDbType.Int);
                para[paracount++].Value = PartyCode;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_RemoveParty(int PartyCode,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_GetNewDocNumber(string DocumentSign, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[1];
            try
            {
                para[paracount] = new SqlParameter("@DocumentSign", SqlDbType.NVarChar,50);
                para[paracount++].Value = DocumentSign;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_GetNewDocNumber(string DocumentSign,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetUserRole(UserRole data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[3];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.UserID;
                para[paracount] = new SqlParameter("@Role", SqlDbType.NVarChar);
                para[paracount++].Value = data.URole;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetUserRole(...) " + ex.Message;
            }
            return para;
        }









    }
}
