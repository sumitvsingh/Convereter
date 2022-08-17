using Converter.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Converter
{
    public interface IGetConversionRate
    {
        public Response getConversionRate(string choice);
        public Response getTemperatureConversion(string choice, Double InputNumber);

    }
    public class ConversionRate : BaseService, IGetConversionRate
    {
        public ConversionRate(string configuration) : base(configuration)
        {
        }



        public Response getConversionRate(string choice)
        {
            Response response = new Response();
            IConverter converter = new Converter();
            object result = new object();
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add(Constants.StoredProcedureParameterName.Choice, choice);

                response = (connection.Query<Response>(Constants.StoredProcedureName.GetConversionRate, queryParameters, commandType: CommandType.StoredProcedure)).AsList().FirstOrDefault();


            }

            return response;


        }
        public Response getTemperatureConversion(string choice, double inputNumber)
        {
            Response response = new Response();
            IConverter converter = new Converter();
            object result = new object();
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add(Constants.StoredProcedureParameterName.Choice, choice);
                queryParameters.Add(Constants.StoredProcedureParameterName.InputNumber, inputNumber);
                //result = ( connection.QuerySingle(Constants.StoredProcedureName.GetConversionRate, queryParameters, commandType: CommandType.StoredProcedure));

                response = (connection.Query<Response>(Constants.StoredProcedureName.GetTemperatureConversion, queryParameters, commandType: CommandType.StoredProcedure)).AsList().FirstOrDefault();


            }

            return response;


        }

    }


}
