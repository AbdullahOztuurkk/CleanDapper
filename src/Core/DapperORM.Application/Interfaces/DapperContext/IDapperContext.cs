namespace DapperORM.Application.Interfaces.DapperContext
{
    public interface IDapperContext
    {
        public void Setup();
        public T Execute<T>();
    }
}
