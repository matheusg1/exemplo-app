namespace PrimeiroTeste.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(long id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(long id);

    }
}
