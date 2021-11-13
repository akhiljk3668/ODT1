using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public interface IBaseRepository
    {
        SqlConnection GetConnection();
        DbCommand GetCommand(string commandText,CommandType commandType);
        Task<T> GetDataReader<T>(string procedureName, List<SqlParameter> sqlParameters =null) where T : class;
        void AddParameter(string Name, object value, ref List<SqlParameter> sqlParameters);
        Task<List<T>> GetDataReaderList<T>(string procedureName, List<SqlParameter> sqlParameters =null) where T : class;
    }
}
