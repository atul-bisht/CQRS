using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Framework.Aggregate
{
    public interface IAggregateRoot
    {
        List<Object> GetEvents();

        void ClearEvents();

        void Apply(object e);

        Guid Id { get; }

        int Version { get; }
    }
}
