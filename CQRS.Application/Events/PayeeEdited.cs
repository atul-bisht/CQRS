using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Events
{
    class PayeeEdited
    {
        public string PayeeName { get; }
        public string BSB { get; }
        public string AccountNumber { get; }

        public PayeeEdited(string accountNumber, string bsb, string name)
        {
            PayeeName = name;
            BSB = bsb;
            AccountNumber = accountNumber;
        }
    }
}
