﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceTable.Table.Logins_Passwords
{
    class Kerio
    {
        public int KerioID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Computer Computer { get; set; }
    }
}