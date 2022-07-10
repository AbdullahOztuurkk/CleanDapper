using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DapperORM.Persistence.Repositories
{
    public abstract class DapperGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public IDapperContext dapperContext;
        private string tableName;
        public DapperGenericRepository(IDapperContext dapperContext, string tableName)
        {
            this.dapperContext = dapperContext;
            this.tableName = tableName;
        }
        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        public void Add(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {tableName} ({stringOfColumns}) values ({stringOfParameters})";
            
            dapperContext.Execute((conn) => {
                conn.Execute(query, entity);
            });
        }

        public void Delete(T entity)
        {
            var query = $"delete from {tableName} where Id = @Id";

            dapperContext.Execute((conn) => {
                conn.Execute(query, entity);
            });

        }

        public void Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {tableName} set {stringOfColumns} where Id = @Id";

            dapperContext.Execute((conn) => {
                conn.Execute(query, entity);
            });

        }

        public T Get(int id)
        {
            var query = $"select * from {tableName} where Id = @Id ";

            using(var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return conn.QueryFirst<T>(query);
            }
        }

        public List<T> GetAll()
        {
            var query = $"select * from {tableName}";

            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return (List<T>)conn.Query<T>(query);
            }
        }
    }
}
