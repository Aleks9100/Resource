using ResourceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
   public class Account
    {
        public int AccountID { get; set; }
        public string Login { get; set; }
        public int PasswordID { get; set; }
        public string Type_Account { get; set; }
        public string LastNamePeople { get; set; }
        public virtual Password Password { get; set; }
    }
}
