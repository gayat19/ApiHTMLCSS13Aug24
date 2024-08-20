using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingAPI.Services
{
    public class CustomerAuthenticationService : ICustomerAuthentication
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerAuthenticationService(IRepository<int,Customer> customerReposirory)
        {
            _customerRepository = customerReposirory;
        }
        public bool Login(CustomerLoginModel model)
        {
            throw new NotImplementedException();
        }

        public bool Register(CustomerLoginModel model)
        {
            Customer customer = new Customer();
            HMACSHA256 hMACSHA = new HMACSHA256();              
            customer.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            customer.Key = hMACSHA.Key;
            return _customerRepository.Add(customer) != null;
        }
    }
}
