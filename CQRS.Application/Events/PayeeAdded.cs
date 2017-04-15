using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Events
{
    public class PayeeAdded
    {
        public string PayeeName { get; }
        public string BSB { get; }
        public string AccountNumber { get; }
        public string Description { get; }

        public PayeeAdded(string name, string bsb, string accountNumber, string description)
        {
            PayeeName = name;
            BSB = bsb;
            AccountNumber = accountNumber;
            Description = description;
        }
    }
}
