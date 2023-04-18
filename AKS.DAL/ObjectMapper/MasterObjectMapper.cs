using AKS.BOL.Master;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ObjectMapper
{
    public class MasterObjectMapper
    {
        string objPath = "AKS.DAL.ObjectMapper.MasterObjectMapper";
        public GLocation Map_GLocation(DataRow dr, ref string pMsg)
        {
            GLocation result = new GLocation();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["GLocation"]))
                        result.LocationName = dr["GLocation"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_GLocation(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public ProfitCentresForList Map_ProfitCentresForList(DataRow dr, ref string pMsg)
        {
            ProfitCentresForList result = new ProfitCentresForList();
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
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ID = int.Parse(dr["ProfitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDescription"]))
                        result.PCDescription = dr["ProfitCentreDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["ProfitCentreAddress"]))
                        result.PCAddress = dr["ProfitCentreAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive =bool.Parse(dr["IsActive"].ToString())?"Yes":"No";
                    if (!DBNull.Value.Equals(dr["MakingCharges"]))
                        result.MakingCharges =int.Parse(dr["MakingCharges"].ToString());
                    if (!DBNull.Value.Equals(dr["GLocation"]))
                        result.GLocation = dr["GLocation"].ToString();
                    if (!DBNull.Value.Equals(dr["DiamondDiscount"]))
                        result.DiamondDiscount =int.Parse(dr["DiamondDiscount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_ProfitCentresForList(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public Category Map_Category(DataRow dr, ref string pMsg) 
        {
            Category result = new Category();
            try
            {
                if (dr != null)
                {                    
                    if (!DBNull.Value.Equals(dr["CategoryCode"]))
                        result.CategoryCode = dr["CategoryCode"].ToString();
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Category(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public CategoryForList Map_CategoryForList(DataRow dr, ref string pMsg)
        {
            CategoryForList result = new CategoryForList();
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
                    if (!DBNull.Value.Equals(dr["CategoryCode"]))
                        result.CategoryCode = dr["CategoryCode"].ToString();
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                    result.IsActiveStr = result.IsActive ? "Yes" : "No";
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_CategoryForList(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public VariantCategory Map_VariantCategory(DataRow dr, ref string pMsg)
        {
            VariantCategory result = new VariantCategory();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.ID =int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["LongText"]))
                        result.LongText = dr["LongText"].ToString();
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_VariantCategory(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public Variant Map_Variant(DataRow dr, ref string pMsg)
        {
            Variant result = new Variant();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.ID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["CatID"]))
                        result.VariantCatID = int.Parse(dr["CatID"].ToString());
                    if (!DBNull.Value.Equals(dr["ShortText"]))
                        result.ShortText = dr["ShortText"].ToString();
                    if (!DBNull.Value.Equals(dr["Purity"]))
                        result.Purity = dr["Purity"].ToString();
                    if (!DBNull.Value.Equals(dr["UOM"]))
                        result.UOM = dr["UOM"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                    if (!DBNull.Value.Equals(dr["RatePerUnit"]))
                        result.RatePerUnit = int.Parse(dr["RatePerUnit"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString().Trim();
                    if (!DBNull.Value.Equals(dr["VariantCatText"]))
                        result.VariantCatText = dr["VariantCatText"].ToString().Trim();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Variant(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public VariantForDT Map_VariantForDT(DataRow dr, ref string pMsg)
        {
            VariantForDT result = new VariantForDT();
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
                    if (!DBNull.Value.Equals(dr["CatID"]))
                        result.VariantCatID = int.Parse(dr["CatID"].ToString());
                    if (!DBNull.Value.Equals(dr["ShortText"]))
                        result.ShortText = dr["ShortText"].ToString();
                    if (!DBNull.Value.Equals(dr["Purity"]))
                        result.Purity = dr["Purity"].ToString();
                    if (!DBNull.Value.Equals(dr["UOM"]))
                        result.UOM = dr["UOM"].ToString();
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                    if (!DBNull.Value.Equals(dr["RatePerUnit"]))
                        result.RatePerUnit = int.Parse(dr["RatePerUnit"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantCatText"]))
                        result.VariantCatText = dr["VariantCatText"].ToString();
                    result.IsActiveStr = result.IsActive ? "Yes" : "No";
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_VariantForDT(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public PartyForList Map_PartyForList(DataRow dr, ref string pMsg)
        {
            PartyForList result = new PartyForList();
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
                    if (!DBNull.Value.Equals(dr["PartyCode"]))
                        result.PartyCode =int.Parse(dr["PartyCode"].ToString());
                    if (!DBNull.Value.Equals(dr["PartyName"]))
                        result.PartyName = dr["PartyName"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyAddress"]))
                        result.PartyAddress = dr["PartyAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["GSTIN"]))
                        result.GSTIN = dr["GSTIN"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyContactNo"]))
                        result.ContactNo = dr["PartyContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyEmailID"]))
                        result.EmailID  = dr["PartyEmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["IsVendor"]))
                        result.IsVendor = bool.Parse(dr["IsVendor"].ToString());
                    if (!DBNull.Value.Equals(dr["IsCustomer"]))
                        result.IsCustomer = bool.Parse(dr["IsCustomer"].ToString());
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive =bool.Parse(dr["IsActive"].ToString());
                    result.IsActiveStr = result.IsActive ? "Yes" : "No";
                    result.IsVendorStr = result.IsVendor ? "Yes" : "No";
                    result.IsCustomerStr = result.IsCustomer ? "Yes" : "No";
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_PartyForList(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public Party Map_Party(DataRow dr, ref string pMsg)
        {
            Party result = new Party();
            try
            {
                if (dr != null)
                {                    
                    if (!DBNull.Value.Equals(dr["PartyCode"]))
                        result.PartyCode = int.Parse(dr["PartyCode"].ToString());
                    if (!DBNull.Value.Equals(dr["PartyName"]))
                        result.PartyName = dr["PartyName"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyAddress"]))
                        result.PartyAddress = dr["PartyAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["GSTIN"]))
                        result.GSTIN = dr["GSTIN"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyContactNo"]))
                        result.ContactNo = dr["PartyContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyEmailID"]))
                        result.EmailID = dr["PartyEmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["IsVendor"]))
                        result.IsVendor = bool.Parse(dr["IsVendor"].ToString());
                    if (!DBNull.Value.Equals(dr["IsCustomer"]))
                        result.IsCustomer = bool.Parse(dr["IsCustomer"].ToString());
                    if (!DBNull.Value.Equals(dr["IsActive"]))
                        result.IsActive = bool.Parse(dr["IsActive"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Party(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }
        public string Map_DocumentNumber(DataRow dr, ref string pMsg)
        {
            string result ="";
            try
            {
                if (dr != null)
                {
                   if (!DBNull.Value.Equals(dr["NewDocumentNumber"]))
                        result = dr["NewDocumentNumber"].ToString();                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_DocumentNumber(DataRow dr, ref string pMsg) " + ex.Message; }
            return result;
        }








    }
}
