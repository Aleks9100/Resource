using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Типы ресурсов к которым можно запросить доступ (Например локальный)
    class ResourceType
    {
        public int ResourceTypeID{ get; set; }
        public string Title { get; set; }

        public virtual List<Resource> Resources { get; set; }
    }
}
