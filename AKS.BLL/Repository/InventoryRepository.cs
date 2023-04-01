using AKS.BLL.IRepository;
using AKS.BOL.Inventory;
using AKS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        InventoryEntity _InventoryEntity;
        string objPath = "AKS.BLL.Repository.InventoryRepository";
        public InventoryRepository()
        {
            _InventoryEntity = new InventoryEntity();
        }
        public List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg)
        {
            return _InventoryEntity.GetGoldRate(City, CDate,ref pMsg);
        }
    }
}
