using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Common
{
    public class BaseEntity
    {
        /// <summary>
        /// Unique Identifier number for each all entities
        /// </summary>
        public int Id { get; set; }
    }
}
