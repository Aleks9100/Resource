using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    class Access_Rights
    {
        public int Access_RightsID { get; set; }
        public List<Visibility> TitleTable { get; set; }
        public List<Visibility> TitleColum { get; set; }
    }
}
