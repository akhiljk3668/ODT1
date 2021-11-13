using Microsoft.Extensions.Options;
using ODT.Data;
using ODT.Repository.Interfaces;
using ODT.Utitlity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ODT.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IOptions<AppSettings> _settings;

        public BaseRepository(IOptions<AppSettings> options)
        {
            _settings = options;
        }
        public DbCommand GetCommand(string commandText, CommandType commandType)
        {
            SqlCommand dbCommand = new SqlCommand(commandText,this.GetConnection());
            dbCommand.CommandType = commandType;
            return dbCommand;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_settings.Value._ODTConnection);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

        public async Task<List<T>> GetDataReaderList<T>(string procedureName,List<SqlParameter> sqlParameters =null) where T : class
        {
            List<T> resultList = new List<T>();
            DbDataReader ds;
            try
            {
                using (var dbCommand = this.GetCommand(procedureName, CommandType.StoredProcedure))
                {
                    if (sqlParameters != null)
                        dbCommand.Parameters.AddRange(sqlParameters.ToArray());
                    using (ds =await dbCommand.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(ds);
                        resultList = dataTable.ConvertDataTable<T>();
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultList;
        }
        public async Task<T> GetDataReader<T>(string procedureName, List<SqlParameter> sqlParameters= null) where T : class
        {
            T result = Activator.CreateInstance<T>();
            DbDataReader ds;
            try
            {
                using (var dbCommand = this.GetCommand(procedureName, CommandType.StoredProcedure))
                {
                    if (sqlParameters!= null)
                        dbCommand.Parameters.AddRange(sqlParameters.ToArray());
                    using (ds = await dbCommand.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(ds);
                        result = dataTable.ConvertDataTable<T>().FirstOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public void AddParameter(string Name, object value, ref List<SqlParameter> sqlParameters)
        {
            sqlParameters = sqlParameters == null ? new List<SqlParameter>() : sqlParameters;
            sqlParameters.Add( new SqlParameter(Name, value != null ? value : DBNull.Value));

        }
    }
}
