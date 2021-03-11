using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Информация о заявках
    class ResourceTicket
    {
        public int ResourceTicketID { get; set; }
        public DateTime Date { get; set; }
        public bool Perfomed { get; set; }
        public int AccessTypeID { get; set; }
        public int ResourceID { get; set; }
        public int PeopleID { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual AccessType AccessType { get; set; }
        public virtual People People { get; set; }

        public string Perfmode()
        {
            if (Perfomed == false) return "Не выполнена";
            else return "Выполнена";
        }
    }
}
