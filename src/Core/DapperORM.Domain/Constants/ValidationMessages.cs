using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Constants
{
    public class ValidationMessages
    {
        public const string Product_Name_Length_Error = "Product name's length must between 3 and 70 characters!";
        public const string Product_Color_Must_be_Known_Color = "Product color must be any known color!";
        public const string Product_Quantity_Must_Greater_Than_Zero = "Product quantity must greater than zero!";    
    }
}
