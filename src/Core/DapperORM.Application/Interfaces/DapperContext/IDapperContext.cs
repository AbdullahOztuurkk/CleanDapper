using System;
using System.Data.SqlClient;

namespace DapperORM.Application.Interfaces.DapperContext
{
    public interface IDapperContext
    {
        public SqlConnection GetConnection();
        public void Execute(Action<SqlConnection> @event);
    }
}
