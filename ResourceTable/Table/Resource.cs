using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public string Title { get; set; }
        public DateTime Date_Start { get; set; }
        public DateTime Date_End { get; set; }
        public int PeopleID { get; set; }
        public virtual People People { get; set; }
    }
}
