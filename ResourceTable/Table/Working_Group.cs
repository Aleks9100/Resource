using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    public class Working_Group
    {
        public int Working_GroupID{get;set;}
        public string Title { get; set; }

        public virtual List<Computer> Computers { get; set; }
    }
}
