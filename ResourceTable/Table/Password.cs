using ResourceTable.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDatabase.Table
{
    public class Password
    {
        public int PasswordID { get; set; }
        public string Passwords { get; set; }
        public string Flag { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; } 
    }
}
