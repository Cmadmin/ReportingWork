using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Infrastructure;
using ReportingWork.Data.Infrastructure;

namespace ReportingWork.Data.Implementation
{
    public class NonQueryFunctions : INonQueryFunctions
    {
        private readonly string _connString;
        private readonly ILogger _logger;
        public NonQueryFunctions(string connString, ILogger logger)
        {
            _connString = connString;
            _logger = logger;
        }

        public int InsertUpdateStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> parameters)
        {
            try
            {
                var result = 0;

                using (var conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        //load params
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        //execute
                        conn.Open();
                        result = cmd.ExecuteNonQuery();                        
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return -1;
            }
        }
    }
}
