using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table
{
    //Должность занимаемые персоналом
    class Position
    {
        public int PositionID { get; set; }
        public string Title { get; set; }

        public virtual List<People> Peoples { get; set; }
    }
}
