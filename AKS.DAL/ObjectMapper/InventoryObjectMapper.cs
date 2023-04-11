using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ObjectMapper
{
    public class InventoryObjectMapper
    {
        string objPath = "AKS.DAL.ObjectMapper.InventoryObjectMapper";
        public DBGoldRate Map_DBGoldRate(DataRow dr, ref string pMsg)
        {
            DBGoldRate result = new DBGoldRate();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.ID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["GoldRate"]))
                        result.GoldRate = double.Parse(dr["GoldRate"].ToString());
                    if (!DBNull.Value.Equals(dr["City"]))
                        result.City = dr["City"].ToString();
                    if (!DBNull.Value.Equals(dr["CDate"]))
                        result.CDate = dr["CDate"].ToString();
                    if (!DBNull.Value.Equals(dr["CTime"]))
                        result.CTime = dr["CTime"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_DBGoldRate(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public AppStock4DT Map_AppStock4DT(DataRow dr, ref string pMsg)
        {
            AppStock4DT result = new AppStock4DT();
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
                    if (!DBNull.Value.Equals(dr["DocumentNumber"]))
                        result.DocumentNumber = dr["DocumentNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["EntryDate"]))
                        result.EntryDate =DateTime.Parse(dr["EntryDate"].ToString()).ToString("dd-MM-yyyy");
                    if (!DBNull.Value.Equals(dr["Vendor"]))
                        result.Vendor = dr["Vendor"].ToString();
                    if (!DBNull.Value.Equals(dr["VendorDocNumber"]))
                        result.VendorDocNumber = dr["VendorDocNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["VendorDocumentDate"]))
                        result.VendorDocumentDate =DateTime.Parse(dr["VendorDocumentDate"].ToString()).ToString("dd-MM-yyyy");
                    if (!DBNull.Value.Equals(dr["DocumentFileName"]))
                        result.DocumentFileName = dr["DocumentFileName"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount =int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["QtyCount"]))
                        result.QtyCount = int.Parse(dr["QtyCount"].ToString());
                    if (!DBNull.Value.Equals(dr["IsApproved"]))
                        result.IsApproved =bool.Parse(dr["IsApproved"].ToString());
                    if (!DBNull.Value.Equals(dr["VendorID"]))
                        result.VendorID = int.Parse(dr["VendorID"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_AppStock4DT(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }





    }
}
