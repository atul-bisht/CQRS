using CQRS.Application.Events;
using CQRS.Application.Framework.Aggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Application.Repository
{
    public class AggregateRepository
    {
        private SqlConnection connection;
        private readonly string AddEvent = "AddEventLog";
        private Dictionary<string, Guid> _aggregateStoreId = new Dictionary<string, Guid>
        {
            {"PayeeAdded", new Guid("C4CBD026-747F-4F1B-91CF-F870E114E74C") },
            {"PayeeEdited", new Guid("6D43BE69-0C88-4EE4-B36F-B0A2D06336D4") },
            {"PayeeDeleted", new Guid("78AE1DE1-3C08-4D71-B89C-E85D9DA4B64F") }
        };
        public AggregateRepository()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Task Save(IAggregateRoot aggregateRoot)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = AddEvent;

                var eventData = aggregateRoot.GetEvents().Select(ToEventData).ToList<EventData>();
                var returnParameter = command.Parameters.Add("@isSuccesful", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;
                Task<int> result = null;
                foreach (var e in eventData)
                {
                    var parameters = GetEventParameters(e);
                    parameters.Add(returnParameter);

                    command.Parameters.Clear();
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();
                    result = command.ExecuteNonQueryAsync();
                    result.ContinueWith(x => connection.Close());
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private EventData ToEventData(object arg)
        {
            return new EventData(Guid.NewGuid(), _aggregateStoreId[arg.GetType().Name], arg.GetType().Name, arg.Serialize());
        }

        private List<SqlParameter> GetEventParameters(EventData eventData)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id",eventData.Id.ToString()),
                new SqlParameter("@AggregateId",eventData.AggregateId.ToString()),
                new SqlParameter("@TimeStamp",DateTime.UtcNow),
                new SqlParameter("@PayLoad",eventData.serialEvent),
                new SqlParameter("@EventName",eventData.EventName)
            };
            return parameters;
        }
    }
}
