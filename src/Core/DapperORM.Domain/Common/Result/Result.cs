using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Common.Result
{
    public class Result : IResult
    {
        public Result(bool success, string Message):this(success)
        {
            this.Message = Message;
        }

        public Result(bool success)
        {
            IsSuccess = success;
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
