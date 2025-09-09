
using Microsoft.AspNetCore.Mvc;
using P5_WebApi.Models.DomainModels;


namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpPost("Add")]
        public IActionResult Add(Product req)
        {
            return Ok(new
            {
                message = "Register Succesfull"
            });
        }

    }
}
