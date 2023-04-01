using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Master
{
    public class Category
    {
        public string CategoryCode { get; set; }
        public string CategoryLongText { get; set; }
        public string HSNCode { get; set; }
        public bool IsActive { get; set; }
        public int ItemCount { get; set; }
    }
    public class CategoryForList : Category
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string IsActiveStr { get; set; }
    }
}
