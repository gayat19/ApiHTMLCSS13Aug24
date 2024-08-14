

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(K key);
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K key);
    }
}
