using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Информация о сотрудниках
    class People
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

        public virtual Organization Organization { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
    }
}
