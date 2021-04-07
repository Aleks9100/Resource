using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Информация о пользователях
    public class Operator
    {
        public int OperatorID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int PeopleID { get; set; }

        public virtual People People { get; set; }
        public virtual Role Role { get; set; }

    }
}
