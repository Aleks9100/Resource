using ResourceTable.Table.Logins_Passwords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Информация о сотрудниках
    public class People
    {
        public int PeopleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string PhoneVoIP { get; set; }


        public int PositionID { get; set; }
        public int OrganizationID { get; set; }
        public int DepartmentID { get; set; }
        public int _1C_ERPID { get; set; }
        public int Cisco_WebexID { get; set; }
        public int DirectumID { get; set; }
        public int Domain_UZID { get; set; }
        public int KerioID { get; set; }
        public int MailID { get; set; }
        public int TruekonffID { get; set; }
        public virtual List<Resource> Resources { get; set; }

        public string Full_Name()
        {
            return $"{LastName} {FirstName[0]}.{MiddleName[0]}";
        } 

        public virtual Organization Organization { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
        public virtual _1C_ERP _1C_ERP { get; set; }
        public virtual Cisco_Webex Cisco_Webex { get; set; }
        public virtual Directum Directum { get; set; }
        public virtual Domain_UZ Domain_UZ { get; set; }
        public virtual Kerio Kerio { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual Truekonff Truekonff { get; set; }
    }
}
