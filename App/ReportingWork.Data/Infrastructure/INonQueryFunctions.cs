using System.Collections.Generic;
using System.Data.SqlClient;

namespace ReportingWork.Data.Infrastructure
{
    public interface INonQueryFunctions
    {
        int InsertUpdateStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> parameters);
    }
}
