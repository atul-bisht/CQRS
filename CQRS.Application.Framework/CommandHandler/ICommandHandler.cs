using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Framework.CommandHandler
{
    public interface ICommandHandler
    {
        void Register<T>(Func<T, Task> handler);
    }
}
