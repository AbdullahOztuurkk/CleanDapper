using System;

namespace DapperORM.Domain.Common
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple = true)]
    public class DapperIgnoreAttribute:Attribute
    {
    }
}
