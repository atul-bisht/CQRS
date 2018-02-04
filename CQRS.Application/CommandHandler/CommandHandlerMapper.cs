using CQRS.Application.Framework.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Application.CommandHandler
{
    public class CommandHandlerMapper
    {
        private Dictionary<string, Func<object, Task>> _handlers = new Dictionary<string, Func<object, Task>>();

        public CommandHandlerMapper(params CommandHandlerBase[] commandHandler)
        {
            foreach (var handler in commandHandler.SelectMany(x => x.handlers))
            {
                _handlers.Add(handler.Key, handler.Value);
            }
        }

        public Func<object, Task> Get(object command)
        {
            return _handlers[command.GetType().Name];
        }
    }
}
