using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(string id)
        {
            return Ok(id);
        }
    }
}
