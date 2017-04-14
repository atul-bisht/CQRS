using CQRS.Application.Command;
using CQRS.Application.Framework.CommandHandler;
using CQRS.Application.Repository;

namespace CQRS.Application.CommandHandler
{
    class AddPayeeCommandHandler : CommandHandlerBase
    {
        public AddPayeeCommandHandler(PayeeRepository payeeRepository)
        {
            Register<AddPayee>(async command =>
            {
                await payeeRepository.Save(command);
            });
        }
    }
}
