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
        bool HasDeleted, HasChanged, HasAdded;
        string PayeeName, Account, BSB, Description, payeeId;
        DateTime TimeStamp;



        public PayeeEncounter(string name, string accountId, string bsb, string description)
            : this()
        {
            Raise(new PayeeAdded(name, bsb, accountId, description));
        }

        public PayeeEncounter()
        {
            Register<PayeeAdded>(When);
            Register<PayeeEdited>(When);
            Register<PayeeDeleted>(When);
        }

        public void When(PayeeDeleted payee)
        {
            HasDeleted = true;
            HasAdded = false;
            payeeId = payee.Id;
            TimeStamp = DateTime.UtcNow;
        }

        public void When(PayeeAdded payee)
        {
            PayeeName = payee.PayeeName;
            Account = payee.AccountNumber;
            BSB = payee.BSB;
            Description = payee.Description;
            TimeStamp = DateTime.UtcNow;
            HasAdded = true;
        }

        public void When(PayeeEdited payee)
        {
            HasChanged = true;
            PayeeName = payee.PayeeName;
            Account = payee.AccountNumber;
            BSB = payee.BSB;
            payeeId = payee.Id;
            TimeStamp = DateTime.UtcNow;
        }

        public void EditPayee(string id, string account, string bsb, string name)
        {
            if (this.HasAdded & !this.HasDeleted)
            {
                Raise(new PayeeEdited(id, account, bsb, name));
            }
            else
            {
                throw new NotSupportedException("This Event isn't applicable on current payee aggregate.");
            }
        }

        public void DeletePayee(string id)
        {
            if (this.HasAdded & !this.HasDeleted)
            {
                Raise(new PayeeDeleted(id));
            }
            else
            {
                throw new NotSupportedException("This Event isn't applicable on current payee aggregate.");
            }
        }
    }
}
