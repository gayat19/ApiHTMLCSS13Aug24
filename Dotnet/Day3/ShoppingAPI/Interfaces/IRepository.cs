namespace ShoppingAPI.Interfaces
{
    public interface IRepository<K,T>
    {
        T Get(K key);
        T Add(T item);
        IList<T> GetAll();
        T Update(T item);
        T Delete(K key);
    }
}
