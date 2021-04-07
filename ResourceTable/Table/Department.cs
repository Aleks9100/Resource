using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }

        public virtual List<People> People { get; set; }
    }
}
