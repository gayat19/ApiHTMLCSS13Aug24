using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Interfaces
{
    public interface ICustomerAuthentication
    {
        bool Login(CustomerLoginModel model);
        bool Register(CustomerLoginModel model);
    }
}
