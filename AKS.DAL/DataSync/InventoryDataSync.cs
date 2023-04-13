﻿using AKS.BOL.Inventory;
using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.DataSync
{
    public class InventoryDataSync
    {
        InventoryParamMapper _InventoryParamMapper;
        CommonParamMapper _CommonParamMapper;
        string objPath = "AKS.DAL.DataSync.InventoryDataSync";
        public InventoryDataSync()
        {
            _InventoryParamMapper = new InventoryParamMapper();
            _CommonParamMapper = new CommonParamMapper();
        }
        public DataTable GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetAppStockDocList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockDocList(...) " + ex.Message; return null; }
        }
        public DataTable GetGoldRate(string City, string CDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[dbo].[getGoldRate]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_getGoldRate(City, CDate, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGoldRate(...) " + ex.Message; return null; }
        }
        public DataTable SetAppStock(AppStockEntry data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[SetAppStock]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetAppStock(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetAppStock(...) " + ex.Message; return null; }
        }
        public DataSet GetAppStocks(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetAppStocks]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStocks(...) " + ex.Message; return null; }
        }
        public DataTable RemoveStockEntryDocument(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[RemoveStockEntryDocument]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStocks(...) " + ex.Message; return null; }
        }




    }
}
