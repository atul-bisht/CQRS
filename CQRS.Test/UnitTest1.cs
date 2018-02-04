using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CQRS.Application.Repository;
using CQRS.Application.CommandHandler;
using System.Threading.Tasks;

namespace CQRS.Test
{
    [TestClass]
    public class UnitTest1
    {
        public async Task RunMain()
        {

        }

        [TestMethod]
        public void AddPayee()
        {
            var payeeRepository = new PayeeRepository();
            var aggregateRepo = new AggregateRepository();
            var commandHandler = new PayeeCommandHandler(payeeRepository, aggregateRepo);
            var mapper = new CommandHandlerMapper(commandHandler);
            var dispatcher = new Dispatcher(mapper);
            for (int i = 0; i < 10; i++)
            {
                dispatcher.Dispatch(new Application.Command.AddPayee()
                {
                    AccountNumber = "123467" + i,
                    BSB = "12345" + i,
                    Name = "Atul",
                    Description = "Business Payee",
                    CustomerNumber = "123",
                }).Wait();
            }
        }

        [TestMethod]
        public void DeletePayee()
        {

            var payeeRepository = new PayeeRepository();
            var aggregateRepo = new AggregateRepository();
            var commandHandler = new PayeeCommandHandler(payeeRepository, aggregateRepo);
            var mapper = new CommandHandlerMapper(commandHandler);
            var dispatcher = new Dispatcher(mapper);
            dispatcher.Dispatch(new Application.Command.DeletePayee()
            {
                PayeeId = 3
            });
        }

        [TestMethod]
        public void ModifyPayee()
        {

            var payeeRepository = new PayeeRepository();
            var aggregateRepo = new AggregateRepository();
            var commandHandler = new PayeeCommandHandler(payeeRepository, aggregateRepo);
            var mapper = new CommandHandlerMapper(commandHandler);
            var dispatcher = new Dispatcher(mapper);
            dispatcher.Dispatch(new Application.Command.EditPayee()
            {
                AccountNumber = "123456",
                Name = "test123",
                BSB = "456",
                PayeeId = "2002"
            });
        }
    }
}
