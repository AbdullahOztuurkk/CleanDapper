using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;
using System.Collections.Generic;

namespace DapperORM.Persistence.Repositories
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {
        public DapperProductRepository(IDapperContext dapperContext) : base(dapperContext, "Products") 
        { 
        }

        public List<Product> GetProductByCategoryId(int Id)
        {
            var query = $"select * from Products where CategoryId = {Id} ";

            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return (List<Product>)conn.Query<List<Product>>(query);
            }
        }
    }
}
