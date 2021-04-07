using ResourceTable.Table.Logins_Passwords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    public class Computer
    {
        public int ComputerID { get; set; }
        public string Indificator { get; set; }
        public string IP { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Domen { get; set; }

        public int Working_GroupID { get; set; }

        public int PeopleID { get; set; }

        public virtual Working_Group Working_Group { get; set; }     
        public virtual People People { get; set; }
    }
}
