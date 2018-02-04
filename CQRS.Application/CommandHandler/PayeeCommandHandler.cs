using CQRS.Application.Aggregate;
using CQRS.Application.Command;
using CQRS.Application.Events;
using CQRS.Application.Framework.Aggregate;
using CQRS.Application.Framework.CommandHandler;
using CQRS.Application.Repository;

namespace CQRS.Application.CommandHandler
{
    public class PayeeCommandHandler : CommandHandlerBase
    {
        public PayeeCommandHandler(PayeeRepository payeeRepository, AggregateRepository aggregateRepository)
        {
            Register<AddPayee>(async (command) =>
            {
                AggregateRoot aggregate = new PayeeEncounter(command.Name, command.AccountNumber, command.BSB, command.Description);
                await aggregateRepository.Save(aggregate);
                await payeeRepository.Save(command);
            });

            Register<EditPayee>(async command =>
            {
                AggregateRoot aggregate = new PayeeEncounter();
                var payeeEvent = new PayeeEdited(command.PayeeId, command.AccountNumber, command.BSB, command.Name);
                aggregate.Apply(payeeEvent);
                await aggregateRepository.Save(aggregate);
                await payeeRepository.Modify(command);
            });

            Register<DeletePayee>(async command =>
            {
                AggregateRoot aggregate = new PayeeEncounter();
                var payeeEvent = new PayeeDeleted(command.PayeeId.ToString());
                aggregate.Apply(payeeEvent);
                await aggregateRepository.Save(aggregate);
                await payeeRepository.Delete(command);
            });
        }
    }
}
