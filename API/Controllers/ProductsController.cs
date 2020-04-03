using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "this will return list of all products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "return single product";
        }
    }
}