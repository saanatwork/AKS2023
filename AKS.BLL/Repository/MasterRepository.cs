﻿using AKS.BLL.IRepository;
using AKS.BOL.Master;
using AKS.BOL.User;
using AKS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.Repository
{
    public class MasterRepository : IMasterRepository
    {
        MasterEntity _MasterEntity;
        string objPath = "AKS.BLL.Repository.MasterRepository";
        public MasterRepository()
        {
            _MasterEntity = new MasterEntity();
        }
        public List<GLocation> GetGLocations(ref string pMsg)
        {
            return _MasterEntity.GetGLocations(ref pMsg);
        }
        public List<ProfitCentresForList> GetProfitCentreList(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetProfitCentreList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText,ref pMsg);
        }
        public bool SetProfitCentreInfo(ProfitCentre data, ref string pMsg) 
        {
            return _MasterEntity.SetUserInfo(data, ref pMsg);
        }
        public List<ProfitCentre> GetProfitCentreInfo(int ProfitCentreID, ref string pMsg) 
        {
            return _MasterEntity.GetProfitCentreInfo(ProfitCentreID, ref pMsg);
        }
        public List<CategoryForList> GetListOfCategory(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetListOfCategory(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public bool SetCategory(Category data, ref string pMsg)
        {
            return _MasterEntity.SetCategory(data, ref pMsg);
        }
        public List<Category> GetCategories(string CategoryCode, ref string pMsg)
        {
            return _MasterEntity.GetCategories(CategoryCode, ref pMsg);
        }
        public List<VariantCategory> GetVariantCategory(ref string pMsg) 
        {
            return _MasterEntity.GetVariantCategory(ref pMsg);
        }
        public List<Variant> GetVariants(int VariantID, ref string pMsg) 
        {
            return _MasterEntity.GetVariants(VariantID, ref pMsg);
        }
        public List<VariantForDT> GetVariantList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetVariantList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public bool SetVariant(Variant data, ref string pMsg) 
        {
            data.Purity = string.IsNullOrEmpty(data.Purity) ? " " : data.Purity;
            data.ShortText= string.IsNullOrEmpty(data.ShortText) ? " " : data.ShortText;
            return _MasterEntity.SetVariant(data, ref pMsg);
        }
        public bool RemoveVariant(int VariantID, ref string pMsg) 
        {
            return _MasterEntity.RemoveVariant(VariantID,ref pMsg);
        }






    }
}
