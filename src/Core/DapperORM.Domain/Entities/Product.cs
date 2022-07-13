using DapperORM.Domain.Common;

namespace DapperORM.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public string Color { get; set; }
        public int UnitsInStock { get; set; }

        //Foreign Key Property
        public int CategoryId { get; set; }
    }
}
