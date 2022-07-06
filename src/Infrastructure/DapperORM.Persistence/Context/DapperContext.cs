using DapperORM.Application.Interfaces.DapperContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DapperORM.Persistence.Context
{
    public class DapperContext : IDapperContext
    {
        IConfiguration configuration;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Execute(Action<SqlConnection> @event)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                @event(connection);
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
