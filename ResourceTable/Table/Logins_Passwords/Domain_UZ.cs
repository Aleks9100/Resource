using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    public class Domain_UZ
    {
        public int Domain_UZID{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
