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
        private readonly ITokenService _tokenService;

        public CustomerAuthenticationService(
                IRepository<int,Customer> customerReposirory,
                ITokenService tokenService)
        {
            _customerRepository = customerReposirory;
            _tokenService = tokenService;
        }
        public AuthenticationResponseModel Login(CustomerLoginModel model)
        {
            var user = _customerRepository.Get(model.Id);
            if (user == null)
                throw new Exception("No such user");
            HMACSHA256 hMACSHA = new HMACSHA256(user.Key);
            var userPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            for (int i = 0; i < userPass.Length; i++)
            {
                if (userPass[i] != user.Password[i])
                    throw new Exception("Invalid username or password");
            }

            return new AuthenticationResponseModel { Token = _tokenService.GenerateToken(user.Name)};
        }

        public bool Register(CustomerLoginModel model)
        {
            Customer customer = new Customer();
            HMACSHA256 hMACSHA = new HMACSHA256();              
            customer.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            customer.Key = hMACSHA.Key;
            customer.Name = model.Name;
            return _customerRepository.Add(customer) != null;
        }
    }
}
