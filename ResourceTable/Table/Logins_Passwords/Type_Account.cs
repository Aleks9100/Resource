using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    public class Type_Account
    {
        public int Type_AccountID { get; set; }
        public string Title { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
}
