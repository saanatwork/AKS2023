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







    }
}
