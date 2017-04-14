using CQRS.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Repository
{
    class PayeeRepository
    {
        public Task<bool> Save(AddPayee addPayee)
        {
            return Task.FromResult<bool>(true);
        }
    }
}
