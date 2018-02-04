using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Framework.CommandHandler
{
    public abstract class CommandHandlerBase : ICommandHandler
    {
        public Dictionary<string, Func<object, Task>> handlers { get; } = new Dictionary<string, Func<object, Task>>();

        public void Register<T>(Func<T, Task> handler)
        {
            handlers.Add(typeof(T).Name, x => handler((T)x));
        }
    }
}
