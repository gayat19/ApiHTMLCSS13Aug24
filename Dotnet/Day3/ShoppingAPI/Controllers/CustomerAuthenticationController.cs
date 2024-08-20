﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAuthenticationController : ControllerBase
    {
        private readonly ICustomerAuthentication _customerAuthentication;

        public CustomerAuthenticationController(ICustomerAuthentication customerAuthentication)
        {
            _customerAuthentication = customerAuthentication;
        }
        [HttpPost]
        public ActionResult Register(CustomerLoginModel model)
        {
            if(_customerAuthentication.Register(model))
                return Ok("User registered");
            else
                return Unauthorized("Unable to add user");
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(CustomerLoginModel model)
        {
            if (_customerAuthentication.Login(model))
                return Ok("Login success");
            else
                return Unauthorized("Invalid username or password");
        }
    }
}
