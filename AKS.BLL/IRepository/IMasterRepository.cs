using AKS.BOL.Common;
using AKS.BOL.Master;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IMasterRepository
    {
        List<GLocation> GetGLocations(ref string pMsg);
        List<ProfitCentresForList> GetProfitCentreList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        List<CategoryForList> GetListOfCategory(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        List<VariantForDT> GetVariantList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        List<PartyForList> GetPartyMasterList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        bool SetProfitCentreInfo(ProfitCentre data, ref string pMsg);
        List<ProfitCentre> GetProfitCentreInfo(int ProfitCentreID, ref string pMsg);
        bool SetCategory(Category data, ref string pMsg);
        List<Category> GetCategories(string CategoryCode, ref string pMsg);
        List<VariantCategory> GetVariantCategory(ref string pMsg);
        List<Variant> GetVariants(int VariantID, ref string pMsg);
        bool SetVariant(Variant data, ref string pMsg);
        bool RemoveVariant(int VariantID, ref string pMsg);
        List<Party> GetPartyInfo(int PartyCode, bool IsVendor, bool IsCustomer, ref string pMsg);
        bool SetPartyInfo(Party data, ref string pMsg);
        bool RemoveParty(int PartyCode, ref string pMsg);
        string GetNewDocNumber(string DocumentSign, ref string pMsg);
        List<CustomComboOptions> SearchPartyInfo(string SearchText, bool IsVendor, bool IsCustomer, ref string pMsg);
        List<CustomComboOptionsWithString> GetRoles(ref string pMsg);
        List<UserRole> GetRoleOfUser(int UserID, ref string pMsg);



    }
}
