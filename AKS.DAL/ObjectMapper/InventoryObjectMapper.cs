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
        public AppStockView Map_AppStockView(DataRow dr, ref string pMsg) 
        {
            AppStockView result = new AppStockView();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["DocumentNumber"]))
                        result.DocumentNumber = dr["DocumentNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["EntryDate"]))
                        result.CreateDate = DateTime.Parse(dr["EntryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["VendorID"]))
                        result.VendorID = int.Parse(dr["VendorID"].ToString());
                    if (!DBNull.Value.Equals(dr["VendorDocNumber"]))
                        result.DocNo = dr["VendorDocNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["VendorDocumentDate"]))
                        result.DocDate = DateTime.Parse(dr["VendorDocumentDate"].ToString());
                    if (!DBNull.Value.Equals(dr["CreateID"]))
                        result.CreatrID = int.Parse(dr["CreateID"].ToString());
                    if (!DBNull.Value.Equals(dr["AppoverID"]))
                        result.ApproverID =int.Parse(dr["AppoverID"].ToString());
                    if (!DBNull.Value.Equals(dr["ApproveDate"]))
                        result.ApproveDate = DateTime.Parse(dr["ApproveDate"].ToString());
                    if (!DBNull.Value.Equals(dr["IsApproved"]))
                        result.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                    if (!DBNull.Value.Equals(dr["DocumentFileName"]))
                        result.DocumentFileName = dr["DocumentFileName"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["QtyCount"]))
                        result.QtyCount = int.Parse(dr["QtyCount"].ToString());
                    if (!DBNull.Value.Equals(dr["MRNNumber"]))
                        result.MRNNumber = dr["MRNNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyName"]))
                        result.PartyName = dr["PartyName"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyAddress"]))
                        result.PartyAddress = dr["PartyAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["GSTIN"]))
                        result.GSTIN = dr["GSTIN"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyContactNo"]))
                        result.PartyContactNo = dr["PartyContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["PartyEmailID"]))
                        result.PartyEmailID = dr["PartyEmailID"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_AppStockView(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public AppStock Map_AppStock(DataRow dr, ref string pMsg) 
        {
            AppStock result = new AppStock();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode = dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemDescription"]))
                        result.ItemDescription = dr["ItemDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());
                    if (!DBNull.Value.Equals(dr["UserRemarks"]))
                        result.Remarks = dr["UserRemarks"].ToString();
                    if (!DBNull.Value.Equals(dr["IsApproved"]))
                        result.IsApproved =bool.Parse(dr["IsApproved"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["IsApproval"]))
                        result.IsApproval =bool.Parse(dr["IsApproval"].ToString());
                    if (!DBNull.Value.Equals(dr["IsOrder"]))
                        result.IsOrder = bool.Parse(dr["IsOrder"].ToString());
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_AppStock(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }




    }
}
