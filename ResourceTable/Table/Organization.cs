using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    class Organization
    {
        public int OrganizationID { get; set; }
        public string Title { get; set; }

        public virtual List<People> Peoples { get; set; }
    }
}
