﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Infrastructure;
using ReportingWork.Data.Infrastructure;

namespace ReportingWork.Data.Implementation
{
    public class QueryFunctions : IQueryFunctions
    {
        private readonly string _connString;
        private readonly ILogger _logger;
        public QueryFunctions(string connString, ILogger logger)
        {
            _connString = connString;
            _logger = logger;
        }

        public DataSet DataSetFromStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> parameters)
        {    
            try
            {
                var ds = new DataSet();

                using (var conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }
                    }
                }

                return ds;
            }
             catch (Exception ex)
             {
                _logger.LogItem(ex.Message);
                return null;
             }
        }

        #region DataTable functions

        public DataTable DataTableFromStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> parameters)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if(conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable DataTableFromStoredProcedure(string storedProcedureName, SqlParameter param)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(param);

                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable DataTableFromStoredProcedure(string storedProcedureName, string paramName, string paramValue)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter(paramName, paramValue));

                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable DataTableFromStoredProcedure(string storedProcedureName)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region DataRowfunctions

        public DataRow DataRowFromStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> parameters)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataRow DataRowFromStoredProcedure(string storedProcedureName, string paramName, string paramValue)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.Add(new SqlParameter(paramName, paramValue));
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                //ignore
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return null;
        }

        public DataRow DataRowFromStoredProcedure(string storedProcedureName)
        {
            SqlConnection conn = null;

            try
            {
                var dt = new DataTable();

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }

                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region non-query-functions

        public int ExecuteNonQueryStoredProc(string storedProcedureName, IEnumerable<SqlParameter> parameters)
        {
            SqlConnection conn = null;

            try
            {
                var result = 0;

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        conn.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return -1;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int ExecuteNonQueryStoredProc(string storedProcedureName, SqlParameter parameter)
        {
            SqlConnection conn = null;

            try
            {
                var result = 0;

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(parameter);
                        conn.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return -1;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int ExecuteNonQueryStoredProc(string storedProcedureName)
        {
            SqlConnection conn = null;

            try
            {
                var result = 0;

                using (conn = new SqlConnection(_connString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogItem(ex.Message);
                return -1;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

    }
}
