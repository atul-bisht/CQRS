using CQRS.Application.Events;
using CQRS.Application.Framework.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CQRS.Application.Aggregate
{
    /// <summary>
    /// By traversal through all events depicts the current state of payee
    /// </summary>
    class PayeeEncounter : AggregateRoot
    {
        bool HasDeleted, HasChanged;
        string PayeeName, Account, BSB, Description;


        public PayeeEncounter(string name, string accountId, string bsb, string description)
            : this()
        {
            Raise(new PayeeAdded(name, bsb, accountId, description));
        }

        public PayeeEncounter()
        {
            Register<PayeeAdded>(When);
            Register<PayeeEdited>(When);
        }

        public void When(PayeeAdded payee)
        {
            PayeeName = payee.PayeeName;
            Account = payee.AccountNumber;
            BSB = payee.BSB;
            Description = payee.Description;
        }

        public void When(PayeeEdited payee)
        {
            HasChanged = true;
            PayeeName = payee.PayeeName;
            Account = payee.AccountNumber;
            BSB = payee.BSB;
        }
    }
}
