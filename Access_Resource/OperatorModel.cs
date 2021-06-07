using ResourceTable.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Resource
{
    public class OperatorModel
    {
        public int OperatorID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public int? PeopleID { get; set; }
        public virtual People People { get; set; }
    }
}
