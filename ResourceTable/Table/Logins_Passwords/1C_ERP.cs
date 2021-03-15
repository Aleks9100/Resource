using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    class _1C_ERP
    {
        public int _1C_ERPID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
