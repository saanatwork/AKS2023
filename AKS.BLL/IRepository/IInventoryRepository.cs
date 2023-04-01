using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IInventoryRepository
    {
        List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg);


    }
}
