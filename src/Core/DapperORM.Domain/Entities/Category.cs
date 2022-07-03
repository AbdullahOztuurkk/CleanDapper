using DapperORM.Domain.Common;
using System.Collections.Generic;

namespace DapperORM.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation property
        public List<Product> Products { get; set; }
    }
}
