using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    public class Cisco_Webex
    {
        public int Cisco_WebexID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual People People { get; set; }
    }
}
