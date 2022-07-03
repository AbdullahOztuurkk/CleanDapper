namespace DapperORM.Domain.Common.Result
{
    public interface IDataResult<T>:IResult
    {
        public T Data { get; }
    }
}
