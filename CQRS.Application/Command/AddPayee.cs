﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Command
{
    public class AddPayee
    {
        public string Name { get; set; }

        public string BSB { get; set; }

        public string AccountNumber { get; set; }

        public string Description { get; set; }

        public string CustomerNumber { get; set; }
    }
}
