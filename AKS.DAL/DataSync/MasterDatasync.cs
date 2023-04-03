using AKS.BOL.Master;
using AKS.DAL.ObjectMapper;
using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.DataSync
{
    public class MasterDatasync
    {
        string objPath = "AKS.DAL.DataSync.MasterDatasync";
        CommonParamMapper _CommonParamMapper;
        MasterParamMapper _MasterParamMapper;
        public MasterDatasync()
        {
            _CommonParamMapper = new CommonParamMapper();
            _MasterParamMapper = new MasterParamMapper();
        }
        public DataTable GetGLocations(ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[GetGLocations]()", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLocations(ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetProfitCentreList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[GetProfitCentreList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetProfitCentreList(...) " + ex.Message; return null; }
        }
        public DataTable GetListOfCategory(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[ListOfCategory]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetListOfCategory(...) " + ex.Message; return null; }
        }
        public DataTable GetVariantList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[GetVariantList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVariantList(...) " + ex.Message; return null; }
        }
        public DataTable SetProfitCentre(BOL.User.ProfitCentre data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[setProfitCentre]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_SetProfitCentre(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetProfitCentre(...) " + ex.Message; return null; }
        }
        public DataTable GetProfitCentreInfo(int ProfitCentreID,ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[getProfitCentreInfo]("+ ProfitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetProfitCentreInfo(int ProfitCentreID,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable SetCategory(Category data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[SetCategory]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_SetCategory(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetCategory(...) " + ex.Message; return null; }
        }
        public DataTable GetCategories(string CategoryCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[GetCategories]('" + CategoryCode + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCategories(string CategoryCode,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetVariantCategory(ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[GetVariantCategory]()", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVariantCategory(ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetVariants(int VariantID,ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[GetVariants]("+ VariantID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVariants(int VariantID,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable SetVariant(Variant data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[SetVariant]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_SetVariant(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetVariant(...) " + ex.Message; return null; }
        }
        public DataTable RemoveVariant(int VariantID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[RemoveVariant]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_RemoveVariant(VariantID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".VariantID(...) " + ex.Message; return null; }
        }






    }
}
