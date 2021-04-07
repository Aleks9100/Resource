using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public int Access_RightsID { get; set; }
        public virtual Access_Rights Access_Right { get; set; }
    }
}
