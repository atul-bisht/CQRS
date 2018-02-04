using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.CommandHandler
{
    public class Dispatcher
    {
        private CommandHandlerMapper _mapper;

        public Dispatcher(CommandHandlerMapper mapper)
        {
            _mapper = mapper;
        }

        public Task Dispatch(object command)
        {
            var handler = _mapper.Get(command);
            return handler(command);

        }
    }
}
