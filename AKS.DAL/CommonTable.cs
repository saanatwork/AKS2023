using AKS.BOL.Accounts;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL
{
    public class CommonTable
    {
        public DataTable UDTable { get; set; }
        public CommonTable(List<SLSTRNDtl> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("ACD", typeof(string));
            UDTable.Columns.Add("SCD", typeof(int));
            UDTable.Columns.Add("Amount", typeof(double));
            UDTable.Columns.Add("CD", typeof(string));
            UDTable.Columns.Add("VoucherDescription", typeof(string));
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["ACD"] = obj.ACD;
                    dr["SCD"] = obj.SCD;
                    dr["Amount"] = obj.Amount;
                    dr["CD"] = obj.CD;
                    dr["VoucherDescription"] = obj.VoucherDescription;                    
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<AppStock> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("sItemCatCode", typeof(string));
            UDTable.Columns.Add("sItemDescription", typeof(string));
            UDTable.Columns.Add("iQty", typeof(int));
            UDTable.Columns.Add("sUserRemarks", typeof(string));
            UDTable.Columns.Add("bIsApproval", typeof(bool));
            UDTable.Columns.Add("bIsOrder", typeof(bool));
            UDTable.Columns.Add("sOrderNo", typeof(string));
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["sItemCatCode"] = obj.ItemCatCode;
                    dr["sItemDescription"] = obj.ItemDescription;
                    dr["iQty"] = obj.Qty;
                    dr["sUserRemarks"] = obj.Remarks;
                    dr["bIsApproval"] = obj.IsApproval;
                    dr["bIsOrder"] = obj.SelectedOrderID != null && obj.SelectedOrderID != "" && obj.SelectedOrderID != "null" ? true : false;
                    dr["sOrderNo"] = obj.SelectedOrderID;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<AppStock> customoptions,bool IsPurchase)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("sItemCatCode", typeof(string));
            UDTable.Columns.Add("sItemDescription", typeof(string));
            UDTable.Columns.Add("iQty", typeof(int));
            UDTable.Columns.Add("sUserRemarks", typeof(string));
            UDTable.Columns.Add("bIsApproval", typeof(bool));
            UDTable.Columns.Add("bIsOrder", typeof(bool));
            UDTable.Columns.Add("dMCWeight", typeof(decimal));
            UDTable.Columns.Add("iMCRate", typeof(int));
            UDTable.Columns.Add("dMCAmount", typeof(decimal));
            UDTable.Columns.Add("iHallMarkCharge", typeof(int));
            UDTable.Columns.Add("iOthercharges", typeof(int));
            UDTable.Columns.Add("dDiscount", typeof(decimal));
            UDTable.Columns.Add("dGrossAmount", typeof(decimal));
            UDTable.Columns.Add("dNetAmount", typeof(decimal));
            UDTable.Columns.Add("sOrderNo", typeof(string));
            UDTable.Columns.Add("sPBILL", typeof(string));
            UDTable.Columns.Add("bIsPBill", typeof(bool));
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["sItemCatCode"] = obj.ItemCatCode;
                    dr["sItemDescription"] = obj.ItemDescription;
                    dr["iQty"] = obj.Qty;
                    dr["sUserRemarks"] = obj.Remarks;
                    dr["bIsApproval"] = obj.IsApproval;
                    dr["bIsOrder"] = obj.SelectedOrderID!=null && obj.SelectedOrderID!="" && obj.SelectedOrderID != "null"? true:false;
                    dr["dMCWeight"] = obj.MCWeight;
                    dr["iMCRate"] = obj.MCRate;
                    dr["dMCAmount"] = obj.MCAmount;
                    dr["iHallMarkCharge"] = obj.HallMarkCharge;
                    dr["iOthercharges"] = obj.Othercharges;
                    dr["dDiscount"] = obj.Discount;
                    dr["dGrossAmount"] = obj.GrossAmount;
                    dr["dNetAmount"] = obj.NetAmount;
                    dr["sOrderNo"] = obj.SelectedOrderID;
                    dr["sPBILL"] = obj.SelectedPBILL;
                    dr["bIsPBill"] = obj.SelectedPBILL != null && obj.SelectedPBILL != "" && obj.SelectedPBILL != "null" ? true : false;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<AppStockVariant> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("iVariantID", typeof(int));
            UDTable.Columns.Add("sVariantText", typeof(string));
            UDTable.Columns.Add("dWeight", typeof(decimal));
            UDTable.Columns.Add("iRate", typeof(int));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["iVariantID"] = obj.VariantID;
                    dr["sVariantText"] = obj.VariantText;
                    dr["dWeight"] = obj.Weight;
                    dr["iRate"] = obj.Rate;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<AppStockVariant> customoptions,bool IsInvoice)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("sItemCode", typeof(string));
            UDTable.Columns.Add("sVariantText", typeof(string));
            UDTable.Columns.Add("dWeight", typeof(decimal));
            UDTable.Columns.Add("iRate", typeof(int));
            UDTable.Columns.Add("dAmount", typeof(decimal));
            UDTable.Columns.Add("dDDisPercentage", typeof(decimal));
            UDTable.Columns.Add("dDDisAmount", typeof(decimal));
            UDTable.Columns.Add("dDGrossAmount", typeof(decimal));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["sItemCode"] = obj.ItemCode;
                    dr["sVariantText"] = obj.VariantText;
                    dr["dWeight"] = obj.Weight;
                    dr["iRate"] = obj.Rate;
                    dr["dAmount"] = obj.Amount;
                    dr["dDDisPercentage"] = obj.DDisPercentage;
                    dr["dDDisAmount"] = obj.DDisAmount;
                    dr["dDGrossAmount"] = obj.DGrossAmount;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<AppStock> customoptions, int InvoiceItem)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("sItemCatCode", typeof(string));
            UDTable.Columns.Add("sItemCode", typeof(string));
            UDTable.Columns.Add("iQty", typeof(int));
            UDTable.Columns.Add("bIsApproval", typeof(bool));
            UDTable.Columns.Add("bIsOrder", typeof(bool));
            UDTable.Columns.Add("dMCWeight", typeof(decimal));
            UDTable.Columns.Add("iMCRate", typeof(int));
            UDTable.Columns.Add("dMCAmount", typeof(decimal));
            UDTable.Columns.Add("iHallMarkCharge", typeof(int));
            UDTable.Columns.Add("iOthercharges", typeof(int));
            UDTable.Columns.Add("dDiscount", typeof(decimal));
            UDTable.Columns.Add("dGrossAmount", typeof(decimal));
            UDTable.Columns.Add("dNetAmount", typeof(decimal));
            UDTable.Columns.Add("dDiscountPer", typeof(decimal));
            UDTable.Columns.Add("dAmtAfterDiscount", typeof(decimal));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["sItemCatCode"] = obj.ItemCatCode;
                    dr["sItemCode"] = obj.ItemCode;
                    dr["iQty"] = obj.Qty;
                    dr["bIsApproval"] = obj.IsApproval;
                    dr["bIsOrder"] = obj.IsOrder;
                    dr["dMCWeight"] = obj.MCWeight;
                    dr["iMCRate"] = obj.MCRate;
                    dr["dMCAmount"] = obj.MCAmount;
                    dr["iHallMarkCharge"] = obj.HallMarkCharge;
                    dr["iOthercharges"] = obj.Othercharges;
                    dr["dDiscount"] = obj.Discount;
                    dr["dGrossAmount"] = obj.GrossAmount;
                    dr["dNetAmount"] = obj.NetAmount;
                    dr["dDiscountPer"] = obj.IDiscountPer;
                    dr["dAmtAfterDiscount"] = obj.IAmtAfterDiscount;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<OrderStock> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("sItemCatCode", typeof(string));
            UDTable.Columns.Add("sItemDescription", typeof(string));
            UDTable.Columns.Add("iQty", typeof(int));
            UDTable.Columns.Add("sUserRemarks", typeof(string));
            UDTable.Columns.Add("dMCWeight", typeof(decimal));
            UDTable.Columns.Add("iMCRate", typeof(int));
            UDTable.Columns.Add("dMCAmount", typeof(decimal));
            UDTable.Columns.Add("iHallMarkCharge", typeof(int));
            UDTable.Columns.Add("iOthercharges", typeof(int));
            UDTable.Columns.Add("dDiscount", typeof(decimal));
            UDTable.Columns.Add("dGrossAmount", typeof(decimal));
            UDTable.Columns.Add("dNetAmount", typeof(decimal));
            UDTable.Columns.Add("dDiscountAmt", typeof(decimal));
            UDTable.Columns.Add("dNetAfterDiscount", typeof(decimal));
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["sItemCatCode"] = obj.ItemCatCode;
                    dr["sItemDescription"] = obj.ItemDescription;
                    dr["iQty"] = obj.Qty;
                    dr["sUserRemarks"] = obj.Remarks;
                    dr["dMCWeight"] = obj.MCWeight;
                    dr["iMCRate"] = obj.MCRate;
                    dr["dMCAmount"] = obj.MCAmount;
                    dr["iHallMarkCharge"] = obj.HallMarkCharge;
                    dr["iOthercharges"] = obj.Othercharges;
                    dr["dDiscount"] = obj.IDiscountPer;
                    dr["dGrossAmount"] = obj.GrossAmount;
                    dr["dNetAmount"] = obj.NetAmount;
                    dr["dDiscountAmt"] = obj.Discount;
                    dr["dNetAfterDiscount"] = obj.IAmtAfterDiscount;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<OrderStockVariant> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iItemSL", typeof(int));
            UDTable.Columns.Add("iVariantID", typeof(int));
            UDTable.Columns.Add("sVariantText", typeof(string));
            UDTable.Columns.Add("dWeight", typeof(decimal));
            UDTable.Columns.Add("iRate", typeof(int));
            UDTable.Columns.Add("dAmount", typeof(decimal));
            UDTable.Columns.Add("dDicount", typeof(decimal));
            UDTable.Columns.Add("dDiscountAmt", typeof(decimal));
            UDTable.Columns.Add("dAmtAfterDiscount", typeof(decimal));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iItemSL"] = obj.ItemSL;
                    dr["iVariantID"] = obj.VariantID;
                    dr["sVariantText"] = obj.VariantText;
                    dr["dWeight"] = obj.Weight;
                    dr["iRate"] = obj.Rate;
                    dr["dAmount"] = obj.DGrossAmount;
                    dr["dDicount"] = obj.DDisPercentage;
                    dr["dDiscountAmt"] = obj.DDisAmount;
                    dr["dAmtAfterDiscount"] = obj.Amount;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<ReturnItemInput> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("sItemCode", typeof(string));
            UDTable.Columns.Add("iQty", typeof(int));
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (var obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["sItemCode"] = obj.ItemCode;
                    dr["iQty"] = obj.Qty;                    
                    UDTable.Rows.Add(dr);
                }
            }
        }


    }
}
