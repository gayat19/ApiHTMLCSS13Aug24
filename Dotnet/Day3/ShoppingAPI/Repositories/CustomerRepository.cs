using ShoppingAPI.Contexts;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly ShoppingCOntext _context;

        public CustomerRepository(ShoppingCOntext context) 
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer Delete(int key)
        {
            var customer = Get(key);
            _context.Remove(customer);
            _context.SaveChanges();
            return customer;

        }

        public Customer Get(int key)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == key);
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Update(Customer item)
        {
           _context.Update(item);
            _context.SaveChanges();
            return item;
            
        }
    }
}
