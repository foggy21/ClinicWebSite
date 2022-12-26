namespace Domain.RepositoryInterfaces
{
    public interface IBaseRepository<T>
    { 
        IEnumerable<T> Select();
        T? Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
