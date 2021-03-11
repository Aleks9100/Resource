using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Информация о ресурсах к которым можно запросить доступ
    class Resource
    {
        public int ResourceID { get; set; }
        public string Title { get; set; }
        public int ResourceTypeID { get; set; }

        public virtual ResourceType ResourceType { get; set; }
    }
}
