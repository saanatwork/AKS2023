using AKS.BOL;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
using AKS.BOL.POS;
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
                    if (!DBNull.Value.Equals(dr["NetPayableAmount"]))
                        result.NetPayableAmount =double.Parse(dr["NetPayableAmount"].ToString());

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

                    result.DocDateStr = result.DocDate.ToString("yyyy-MM-dd");
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
                    if (!DBNull.Value.Equals(dr["OrderNumber"]))
                        result.SelectedOrderID = dr["OrderNumber"].ToString();
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
                    result.DocDateStr = result.DocDate.ToString("yyyy-MM-dd");
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
                    if (!DBNull.Value.Equals(dr["OrderNumber"]))
                        result.SelectedOrderID = dr["OrderNumber"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_PurchaseItem(DataRow dr,ref string pMsg) " + ex.Message; }
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
        public Invoice4DT Map_Invoice4DT(DataRow dr, ref string pMsg)
        {
            Invoice4DT result = new Invoice4DT();
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
                    if (!DBNull.Value.Equals(dr["InvoiceNumber"]))
                        result.InvoiceNumber = dr["InvoiceNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["InvoiceDate"]))
                        result.InvoiceDate = DateTime.Parse(dr["InvoiceDate"].ToString()).ToString("dd-MM-yyyy");
                    if (!DBNull.Value.Equals(dr["EntryDate"]))
                        result.EntryDate = DateTime.Parse(dr["EntryDate"].ToString()).ToString("dd-MM-yyyy hh:mm:ss tt");
                    if (!DBNull.Value.Equals(dr["CustomerID"]))
                        result.CustomerID =int.Parse(dr["CustomerID"].ToString());
                    if (!DBNull.Value.Equals(dr["CustomerName"]))
                        result.CustomerName = dr["CustomerName"].ToString();
                    if (!DBNull.Value.Equals(dr["CustomerContact"]))
                        result.CustomerContact = dr["CustomerContact"].ToString();                    
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["QtyCount"]))
                        result.QtyCount = int.Parse(dr["QtyCount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetPayableAmount"]))
                        result.NetPayableAmount = double.Parse(dr["NetPayableAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["AmountReceived"]))
                        result.AmountReceived = double.Parse(dr["AmountReceived"].ToString());
                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Invoice4DT(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public InvoiceItemVariants Map_InvoiceItemVariants(DataRow dr, ref string pMsg) 
        {
            InvoiceItemVariants result = new InvoiceItemVariants();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["VariantText"]))
                        result.VariantText = dr["VariantText"].ToString();
                    if (!DBNull.Value.Equals(dr["Weight"]))
                        result.Weight =double.Parse(dr["Weight"].ToString());
                    if (!DBNull.Value.Equals(dr["Rate"]))
                        result.Rate = int.Parse(dr["Rate"].ToString());
                    if (!DBNull.Value.Equals(dr["Amount"]))
                        result.Amount = double.Parse(dr["Amount"].ToString());
                    if (!DBNull.Value.Equals(dr["DDisPercentage"]))
                        result.DDisPercentage = double.Parse(dr["DDisPercentage"].ToString());
                    if (!DBNull.Value.Equals(dr["DDisAmount"]))
                        result.DDisAmount =double.Parse(dr["DDisAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["DGrossAmount"]))
                        result.DGrossAmount =double.Parse(dr["DGrossAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantID"]))
                        result.VariantID = int.Parse(dr["VariantID"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_InvoiceItemVariants(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public InvoiceItem Map_InvoiceItem(DataRow dr, ref string pMsg) 
        {
            InvoiceItem result = new InvoiceItem();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["UItemCode"]))
                        result.UItemCode = dr["UItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());
                    if (!DBNull.Value.Equals(dr["IsApproval"]))
                        result.IsApproval = bool.Parse(dr["IsApproval"].ToString());
                    if (!DBNull.Value.Equals(dr["IsOrder"]))
                        result.IsOrder = bool.Parse(dr["IsOrder"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["ProfitCentreID"].ToString());
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
                    if (!DBNull.Value.Equals(dr["DiscountAmount"]))
                        result.DiscountAmount = double.Parse(dr["DiscountAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["GrossAmount"]))
                        result.GrossAmount = double.Parse(dr["GrossAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetAmount"]))
                        result.NetAmount = double.Parse(dr["NetAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["DiscountPer"]))
                        result.DiscountPer = double.Parse(dr["DiscountPer"].ToString());
                    if (!DBNull.Value.Equals(dr["AmtAfterDiscount"]))
                        result.AmtAfterDiscount = double.Parse(dr["AmtAfterDiscount"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_InvoiceItem(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public Invoice Map_Invoice(DataRow dr, ref string pMsg) 
        {
            Invoice result = new Invoice();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["InvoiceNumber"]))
                        result.InvoiceNumber =dr["InvoiceNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["EntryDate"]))
                        result.EntryDate =DateTime.Parse(dr["EntryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["InvoiceDate"]))
                        result.InvoiceDate =DateTime.Parse(dr["InvoiceDate"].ToString());
                    if (!DBNull.Value.Equals(dr["CustomerID"]))
                        result.CustomerID =int.Parse(dr["CustomerID"].ToString());
                    if (!DBNull.Value.Equals(dr["CustomerName"]))
                        result.CustomerName = dr["CustomerName"].ToString();
                    if (!DBNull.Value.Equals(dr["CustomerAddress"]))
                        result.CustomerAddress = dr["CustomerAddress"].ToString();
                    if (!DBNull.Value.Equals(dr["CustomerContactNo"]))
                        result.CustomerContactNo = dr["CustomerContactNo"].ToString();
                    if (!DBNull.Value.Equals(dr["CustomerEmailID"]))
                        result.CustomerEmailID = dr["CustomerEmailID"].ToString();
                    if (!DBNull.Value.Equals(dr["CustomerPAN"]))
                        result.CustomerPAN = dr["CustomerPAN"].ToString();
                    if (!DBNull.Value.Equals(dr["CreateID"]))
                        result.CreateID = int.Parse(dr["CreateID"].ToString());
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["DocumentFileName"]))
                        result.DocumentFileName = dr["DocumentFileName"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["QtyCount"]))
                        result.QtyCount = int.Parse(dr["QtyCount"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["ProfitCentreID"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreName"]))
                        result.ProfitCentreName =dr["ProfitCentreName"].ToString();
                    if (!DBNull.Value.Equals(dr["ProfitCentreAddress"]))
                        result.ProfitCentreAddress =dr["ProfitCentreAddress"].ToString();
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
                    if (!DBNull.Value.Equals(dr["CashDiscount"]))
                        result.CashDiscount = double.Parse(dr["CashDiscount"].ToString());
                    if (!DBNull.Value.Equals(dr["AmountReceived"]))
                        result.AmountReceived = double.Parse(dr["AmountReceived"].ToString());
                    if (!DBNull.Value.Equals(dr["BalanceAmount"]))
                        result.BalanceAmount = double.Parse(dr["BalanceAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["ModeOfRecieve"]))
                        result.ModeOfRecieve = int.Parse(dr["ModeOfRecieve"].ToString());
                    if (!DBNull.Value.Equals(dr["RefNo"]))
                        result.RefNo = dr["RefNo"].ToString();
                    if (!DBNull.Value.Equals(dr["JVNo"]))
                        result.JVNo = dr["JVNo"].ToString();
                    if (!DBNull.Value.Equals(dr["CRNo"]))
                        result.CRNo = dr["CRNo"].ToString();
                    if (!DBNull.Value.Equals(dr["IsIGST"]))
                        result.IsIGST =bool.Parse(dr["IsIGST"].ToString());

                    result.ReceiveModeStr = MyHelper.GetModeOfPaymentDesc(result.ModeOfRecieve);
                    result.BillAmountInWords = MyHelper.ConvertToWords(result.NetPayableAmount);
                    //result.ReceivedAmountInWords = MyHelper.ConvertToWords(result.AmountReceived);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_Invoice(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public AppStockVariant Map_AppStockVariant(DataRow dr, ref string pMsg) 
        {
            AppStockVariant result = new AppStockVariant();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["VariantText"]))
                        result.VariantText = dr["VariantText"].ToString();
                    if (!DBNull.Value.Equals(dr["Weight"]))
                        result.Weight = double.Parse(dr["Weight"].ToString());
                    if (!DBNull.Value.Equals(dr["Rate"]))
                        result.Rate = int.Parse(dr["Rate"].ToString());
                    if (!DBNull.Value.Equals(dr["Amount"]))
                        result.Amount = double.Parse(dr["Amount"].ToString());                    
                    if (!DBNull.Value.Equals(dr["VariantID"]))
                        result.VariantID = int.Parse(dr["VariantID"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString().Trim();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_AppStockVariant(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public StockSummary4DT Map_StockSummary4DT(DataRow dr, ref string pMsg)
        {
            StockSummary4DT result = new StockSummary4DT();
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
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode = dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCatLongText"]))
                        result.ItemCatLongText = dr["ItemCatLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty =int.Parse(dr["Qty"].ToString());
                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_StockSummary4DT(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public StockSummary Map_StockSummary(DataRow dr, ref string pMsg)
        {
            StockSummary result = new StockSummary();
            try
            {
                if (dr != null)
                {                    
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode = dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCatLongText"]))
                        result.ItemCatLongText = dr["ItemCatLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());

                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_StockSummary(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public StockItems Map_StockItems(DataRow dr, ref string pMsg)
        {
            StockItems result = new StockItems();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode = dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCatLongText"]))
                        result.ItemCatLongText = dr["ItemCatLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["UserRemarks"]))
                        result.UserRemarks = dr["UserRemarks"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemDescription"]))
                        result.ItemDescription = dr["ItemDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemQty"]))
                        result.ItemQty =int.Parse(dr["ItemQty"].ToString());
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_StockItems(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public StockItemDetails Map_StockItemDetails(DataRow dr, ref string pMsg)
        {
            StockItemDetails result = new StockItemDetails();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode = dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCatLongText"]))
                        result.ItemCatLongText = dr["ItemCatLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
                    if (!DBNull.Value.Equals(dr["UserRemarks"]))
                        result.UserRemarks = dr["UserRemarks"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemDescription"]))
                        result.ItemDescription = dr["ItemDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemQty"]))
                        result.ItemQty = int.Parse(dr["ItemQty"].ToString());
                    if (!DBNull.Value.Equals(dr["DocumentNumber"]))
                        result.DocumentNumber = dr["DocumentNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["IsApproval"]))
                        result.IsApproval =bool.Parse(dr["IsApproval"].ToString());
                    if (!DBNull.Value.Equals(dr["TranTag"]))
                        result.TranTag = dr["TranTag"].ToString();
                    if (!DBNull.Value.Equals(dr["UDocNumber"]))
                        result.UDocNumber = dr["UDocNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["UDocDate"]))
                        result.UDocDate =DateTime.Parse(dr["UDocDate"].ToString());
                    if (!DBNull.Value.Equals(dr["Vendorid"]))
                        result.Vendorid =int.Parse(dr["Vendorid"].ToString());
                    if (!DBNull.Value.Equals(dr["VendorName"]))
                        result.VendorName = dr["VendorName"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_StockItemDetails(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public OrderList Map_OrderList(DataRow dr, ref string pMsg) 
        {
            OrderList result = new OrderList();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["DocumentNumber"]))
                        result.DocumentNumber = dr["DocumentNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["EntryDate"]))
                        result.EntryDate =DateTime.Parse(dr["EntryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["Customer"]))
                        result.Customer = dr["Customer"].ToString();
                    if (!DBNull.Value.Equals(dr["AmountReceived"]))
                        result.AmountReceived =double.Parse(dr["AmountReceived"].ToString());
                    if (!DBNull.Value.Equals(dr["ExpectedDeliveryDate"]))
                        result.ExpectedDeliveryDate =DateTime.Parse(dr["ExpectedDeliveryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount =int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["TotalRecords"]))
                        result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                    if (!DBNull.Value.Equals(dr["OrderStatus"]))
                        result.OrderStatus =int.Parse(dr["OrderStatus"].ToString());
                    if (!DBNull.Value.Equals(dr["OrderStatusStr"]))
                        result.OrderStatusStr =dr["OrderStatusStr"].ToString();
                    result.EntryDateStr = result.EntryDate.ToString("dd-MM-yyyy");
                    result.ExpectedDeliveryDateStr = result.ExpectedDeliveryDate.ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_OrderList(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public ViewOrder Map_ViewOrder(DataRow dr, ref string pMsg)
        {
            ViewOrder result = new ViewOrder();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["DocumentNumber"]))
                        result.DocumentNumber = dr["DocumentNumber"].ToString();
                    if (!DBNull.Value.Equals(dr["EmtryDate"]))
                        result.EntryDate = DateTime.Parse(dr["EmtryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["CustomerID"]))
                        result.CustomerID =int.Parse(dr["CustomerID"].ToString());
                    if (!DBNull.Value.Equals(dr["CreateID"]))
                        result.CreatrID = int.Parse(dr["CreateID"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCount"]))
                        result.ItemCount = int.Parse(dr["ItemCount"].ToString());
                    if (!DBNull.Value.Equals(dr["ProfitCentreID"]))
                        result.ProfitCentreID = int.Parse(dr["ProfitCentreID"].ToString());
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
                    if (!DBNull.Value.Equals(dr["ExpectedDeliveryDate"]))
                        result.ExpectedDeliveryDate = DateTime.Parse(dr["ExpectedDeliveryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["Status"]))
                        result.Status = int.Parse(dr["Status"].ToString());
                    if (!DBNull.Value.Equals(dr["StockDocumentnumber"]))
                        result.StockDocumentnumber = dr["StockDocumentnumber"].ToString();
                    if (!DBNull.Value.Equals(dr["POSDocumentnumber"]))
                        result.POSDocumentnumber = dr["POSDocumentnumber"].ToString();
                    if (!DBNull.Value.Equals(dr["StockEntryDate"]))
                        result.StockEntryDate = DateTime.Parse(dr["StockEntryDate"].ToString());
                    if (!DBNull.Value.Equals(dr["DeliverDate"]))
                        result.DeliverDate = DateTime.Parse(dr["DeliverDate"].ToString());
                    if (!DBNull.Value.Equals(dr["AmountReceived"]))
                        result.AmountReceived = double.Parse(dr["AmountReceived"].ToString());
                    if (!DBNull.Value.Equals(dr["ModeoofPayment"]))
                        result.MOP =int.Parse(dr["ModeoofPayment"].ToString());
                    if (!DBNull.Value.Equals(dr["PaymentRef"]))
                        result.PaymentRef = dr["PaymentRef"].ToString();
                    if (!DBNull.Value.Equals(dr["ApproxPayable"]))
                        result.ApproxPayable =double.Parse(dr["ApproxPayable"].ToString());
                    result.StausText = MyHelper.GetOrderStatusText(result.Status);
                    result.ModeodofPayment = MyHelper.GetModeOfPaymentDesc(result.MOP);
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
                    if (!DBNull.Value.Equals(dr["ProfitCentreDesc"]))
                        result.ProfitCentreDesc = dr["ProfitCentreDesc"].ToString();
                    if (!DBNull.Value.Equals(dr["CreatorName"]))
                        result.CreatorName = dr["CreatorName"].ToString();
                    if (!DBNull.Value.Equals(dr["ApproverName"]))
                        result.ApproverName = dr["ApproverName"].ToString();
                    result.AmountReceivedInWords = MyHelper.ConvertToWords(result.AmountReceived);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_ViewOrder(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public OrderStock Map_OrderStock(DataRow dr, ref string pMsg)
        {
            OrderStock result = new OrderStock();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["ItemCatCode"]))
                        result.ItemCatCode =dr["ItemCatCode"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemDescription"]))
                        result.ItemDescription = dr["ItemDescription"].ToString();
                    if (!DBNull.Value.Equals(dr["Qty"]))
                        result.Qty = int.Parse(dr["Qty"].ToString());
                    if (!DBNull.Value.Equals(dr["UserRemarks"]))
                        result.Remarks = dr["UserRemarks"].ToString();
                    if (!DBNull.Value.Equals(dr["ItemCode"]))
                        result.ItemCode = dr["ItemCode"].ToString();
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
                        result.IDiscountPer = double.Parse(dr["Discount"].ToString());
                    if (!DBNull.Value.Equals(dr["GrossAmount"]))
                        result.GrossAmount = double.Parse(dr["GrossAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetAmount"]))
                        result.NetAmount = double.Parse(dr["NetAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["DiscountAmount"]))
                        result.Discount =double.Parse(dr["DiscountAmount"].ToString());
                    if (!DBNull.Value.Equals(dr["NetAfterDiscount"]))
                        result.IAmtAfterDiscount =double.Parse(dr["NetAfterDiscount"].ToString());
                    if (!DBNull.Value.Equals(dr["CategoryLongText"]))
                        result.CategoryLongText = dr["CategoryLongText"].ToString();
                    if (!DBNull.Value.Equals(dr["HSNCode"]))
                        result.HSNCode = dr["HSNCode"].ToString();
                    
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_OrderStock(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }
        public OrderStockVariant Map_OrderStockVariant(DataRow dr, ref string pMsg)
        {
            OrderStockVariant result = new OrderStockVariant();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ItemSL"]))
                        result.ItemSL = int.Parse(dr["ItemSL"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantID"]))
                        result.VariantID =int.Parse(dr["VariantID"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantText"]))
                        result.VariantText = dr["VariantText"].ToString();
                    if (!DBNull.Value.Equals(dr["Weight"]))
                        result.Weight = double.Parse(dr["Weight"].ToString());
                    if (!DBNull.Value.Equals(dr["Rate"]))
                        result.Rate =int.Parse(dr["Rate"].ToString());
                    if (!DBNull.Value.Equals(dr["Amount"]))
                        result.DGrossAmount = double.Parse(dr["Amount"].ToString());
                    if (!DBNull.Value.Equals(dr["Dicount"]))
                        result.DDisPercentage = double.Parse(dr["Dicount"].ToString());
                    if (!DBNull.Value.Equals(dr["DiscountAmt"]))
                        result.DDisAmount = double.Parse(dr["DiscountAmt"].ToString());
                    if (!DBNull.Value.Equals(dr["VariantColumn"]))
                        result.VariantColumn = dr["VariantColumn"].ToString().Trim();
                    if (!DBNull.Value.Equals(dr["AmtAfterDiscount"]))
                        result.Amount = double.Parse(dr["AmtAfterDiscount"].ToString());                                   

                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_OrderStockVariant(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }




    }
}
