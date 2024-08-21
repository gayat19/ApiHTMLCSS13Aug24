using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Interfaces
{
    public interface ICustomerAuthentication
    {
        AuthenticationResponseModel Login(CustomerLoginModel model);
        bool Register(CustomerLoginModel model);
    }
}
