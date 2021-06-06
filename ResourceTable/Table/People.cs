using ResourceTable.Table;
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
        public virtual List<Resource> Resources { get; set; }

        public string Full_Name()
        {
            return $"{LastName} {FirstName[0]}.{MiddleName[0]}";
        } 

        public virtual Organization Organization { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
     //   public virtual List<Account> Accounts { get; set; }
    }
}
