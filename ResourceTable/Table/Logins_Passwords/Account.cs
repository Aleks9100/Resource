using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
   public class Account
    {
        public int AccountID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Type_AccountID { get; set; }
        public int PeopleID { get; set; }
        public virtual People People { get; set; }
        public virtual Type_Account Type_Account { get; set; }
    }
}
