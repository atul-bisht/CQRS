using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Events
{
    class PayeeDeleted
    {
        public string Id { get; set; }

        public PayeeDeleted(string id)
        {
            Id = id;
        }
    }
}
