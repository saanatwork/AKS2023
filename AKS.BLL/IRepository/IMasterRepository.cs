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
        bool SetProfitCentreInfo(ProfitCentre data, ref string pMsg);
        List<ProfitCentre> GetProfitCentreInfo(int ProfitCentreID, ref string pMsg);
        bool SetCategory(Category data, ref string pMsg);
        List<Category> GetCategories(string CategoryCode, ref string pMsg);





    }
}
