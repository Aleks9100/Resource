using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    public class Directum
    {
        public int DirectumID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual People People { get; set; }
    }
}
