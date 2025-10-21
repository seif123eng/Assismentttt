namespace Assisment.GenericRepo
{
    public interface IGeneric<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(int id);
        public Task AddAsync (T entity);
        public Task UpdateAsync (T entity);
        public Task DeleteAsync (T entity);
        public Task SaveAsync();
    }
}
