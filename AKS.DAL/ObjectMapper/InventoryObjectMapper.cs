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
                    if (!DBNull.Value.Equals(dr["MRNNO"]))
                        result.MRNNumber = dr["MRNNO"].ToString();
                    if (!DBNull.Value.Equals(dr["MRNDate"]))
                    {
                        DateTime mdt = DateTime.Parse(dr["MRNDate"].ToString());
                        result.MRNDate = mdt.Year>1?mdt.ToString("dd-MM-yyyy"):"-";
                    }
                        

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
                    if (!DBNull.Value.Equals(dr["profitCentreID"]))
                        result.ProfitCentreID =int.Parse(dr["profitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDesc"]))
                        result.ProfitCentreDesc = dr["ProfitCentreDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["ApproverName"]))
                        result.ApproverName = dr["ApproverName"].ToString();
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
        public AppStockView Map_PurchaseView(DataRow dr, ref string pMsg)
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
                        result.ApproverID = int.Parse(dr["AppoverID"].ToString());
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
                    if (!DBNull.Value.Equals(dr["profitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["profitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreDesc"]))
                        result.ProfitCentreDesc = dr["ProfitCentreDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["ApproverName"]))
                        result.ApproverName = dr["ApproverName"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemTotal"]))
                        result.ItemTotal = double.Parse(dr["ItemTotal"].ToString());
                    if (!DBNull.Value.Equals(dr["TradeDiscount"]))
                        result.TradeDiscount = double.Parse(dr["TradeDiscount"].ToString());
                    if (!DBNull.Value.Equals(dr["TaxableAmount"]))
                        result.TaxableAmount = double.Parse(dr["TaxableAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["GST"]))
                        result.GST = double.Parse(dr["GST"].ToString());
                    if (!DBNull.Value.Equals(dr["GSTAmount"]))
                        result.GSTAmount = double.Parse(dr["GSTAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetPayableAmount"]))
                        result.NetPayableAmount = double.Parse(dr["NetPayableAmount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_PurchaseView(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public AppStock Map_PurchaseItem(DataRow dr, ref string pMsg)
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
                        result.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["IsApproval"]))
                        result.IsApproval = bool.Parse(dr["IsApproval"].ToString());
                    if (!DBNull.Value.Equals(dr["IsOrder"]))
                        result.IsOrder = bool.Parse(dr["IsOrder"].ToString());
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                    if (!DBNull.Value.Equals(dr["MCWeight"]))
                        result.MCWeight = double.Parse(dr["MCWeight"].ToString());
                    if (!DBNull.Value.Equals(dr["MCRate"]))
                        result.MCRate = int.Parse(dr["MCRate"].ToString());
                    if (!DBNull.Value.Equals(dr["MCAmount"]))
                        result.MCAmount = double.Parse(dr["MCAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["HallMarkCharge"]))
                        result.HallMarkCharge = int.Parse(dr["HallMarkCharge"].ToString());
                    if (!DBNull.Value.Equals(dr["Othercharges"]))
                        result.Othercharges = int.Parse(dr["Othercharges"].ToString());
                    if (!DBNull.Value.Equals(dr["Discount"]))
                        result.Discount = double.Parse(dr["Discount"].ToString());
                    if (!DBNull.Value.Equals(dr["GrossAmount"]))
                        result.GrossAmount = double.Parse(dr["GrossAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetAmount"]))
                        result.NetAmount = double.Parse(dr["NetAmount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_AppStock(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public SalesItemVriant Map_SalesItemVriant(DataRow dr, ref string pMsg)
        {
            SalesItemVriant result = new SalesItemVriant();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["VariantID"]))
                        result.VariantID = int.Parse(dr["VariantID"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantDescription"]))
                        result.VariantDescription = dr["VariantDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString();
                    if (!DBNull.Value.Equals(dr["Purity"]))
                        result.Purity = dr["Purity"].ToString();
                    if (!DBNull.Value.Equals(dr["VariantCatText"]))
                        result.VariantCatText = dr["VariantCatText"].ToString();
                    if (!DBNull.Value.Equals(dr["RatePerUnit"]))
                        result.RatePerUnit = double.Parse(dr["RatePerUnit"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantWt"]))
                        result.VariantWt =double.Parse(dr["VariantWt"].ToString());                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_SalesItemVriant(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }




    }
}
