using AKS.BOL.Inventory;
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
                    dr["bIsOrder"] = obj.IsOrder;
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
    }
}
