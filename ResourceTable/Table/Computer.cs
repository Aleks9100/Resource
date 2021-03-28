using ResourceTable.Table.Logins_Passwords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    class Computer
    {
        public int ComputerID { get; set; }
        public string Indificator { get; set; }
        public string IP { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Domen { get; set; }

        public int Working_GroupID { get; set; }
        public int _1C_ERPID { get; set; }
        public int Cisco_WebexID { get; set; }
        public int DirectumID { get; set; }
        public int Domain_UZID { get; set; }
        public int KerioID { get; set; }
        public int MailID { get; set; }
        public int TruekonffID { get; set; }
        public int PeopleID { get; set; }

        public virtual Working_Group Working_Group { get; set; }
        public virtual _1C_ERP _1C_ERP { get; set; }
        public virtual Cisco_Webex Cisco_Webex { get; set; }
        public virtual Directum Directum { get; set; }
        public virtual Domain_UZ Domain_UZ { get; set; }
        public virtual Kerio Kerio { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual Truekonff Truekonff { get; set; }
        public virtual People People { get; set; }
    }
}
