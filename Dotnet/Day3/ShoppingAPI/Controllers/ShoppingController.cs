using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok("Everyone can view");
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetOrders(CustomerLoginModel loginModel)
        {
            return Ok("Only people with access");
        }
    }
}
