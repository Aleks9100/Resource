using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResourceTable.Table
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public List<Visibility> TitleTable { get; set; }
        public List<Visibility> TitleColumn { get; set; }
    }
}
