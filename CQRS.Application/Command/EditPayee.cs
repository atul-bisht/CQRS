using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Command
{
    public class EditPayee
    {
        public string PayeeId { get; set; }

        public string Name { get; set; }

        public string BSB { get; set; }

        public string AccountNumber { get; set; }
    }
}
