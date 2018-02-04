using CQRS.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace CQRS.Application.Repository
{
    public class PayeeRepository
    {
        private readonly string AddPayee = "AddPayee";
        private readonly string ModifyPayee = "ModifyPayee";
        private readonly string DeletePayee = "Deletepayee";
        private SqlConnection connection;

        public PayeeRepository()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AchWire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Task<int> Delete(DeletePayee deletePayee)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = DeletePayee;

                var parameters = GetPayeeParameters(deletePayee);
                var returnParameter = command.Parameters.Add("@isSuccesful", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;
                parameters.Add(returnParameter);
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters.ToArray());

                connection.OpenAsync().Wait();
                var result = command.ExecuteNonQueryAsync();
                //result.ContinueWith(x => connection.Close());
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public Task Modify(EditPayee editPayee)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = ModifyPayee;

                var parameters = GetPayeeParameters(editPayee);
                var returnParameter = command.Parameters.Add("@isSuccesful", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;
                parameters.Add(returnParameter);

                command.Parameters.Clear();
                command.Parameters.AddRange(parameters.ToArray());

                connection.OpenAsync().Wait();
                var result = command.ExecuteNonQueryAsync();
                result.ContinueWith(x => connection.Close());
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }



        public Task<int> Save(AddPayee addPayee)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = AddPayee;

                var parameters = GetPayeeParameters(addPayee);
                var returnParameter = command.Parameters.Add("@isSuccesful", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;
                parameters.Add(returnParameter);

                command.Parameters.Clear();
                command.Parameters.AddRange(parameters.ToArray());

                connection.Open();
                var result = command.ExecuteNonQueryAsync();
                result.ContinueWith(x => connection.Close());
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private List<SqlParameter> GetPayeeParameters(AddPayee addPayee)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@name",addPayee.Name),
                new SqlParameter("@AccounNumber",addPayee.AccountNumber),
                new SqlParameter("@Bsb",addPayee.BSB),
                new SqlParameter("@Description",addPayee.Description),
                new SqlParameter("@CustomerNumber",addPayee.CustomerNumber)
            };
            return parameters;
        }

        private List<SqlParameter> GetPayeeParameters(EditPayee editPayee)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PayeeId",editPayee.PayeeId),
                new SqlParameter("@name",editPayee.Name),
                new SqlParameter("@AccounNumber",editPayee.AccountNumber),
                new SqlParameter("@Bsb",editPayee.BSB)
            };
            return parameters;
        }

        private List<SqlParameter> GetPayeeParameters(DeletePayee editPayee)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PayeeId",editPayee.PayeeId)
            };
            return parameters;
        }
    }
}
