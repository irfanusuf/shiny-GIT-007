using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {


        [HttpGet("Pay")]
        public ActionResult PayForTheOrder(Guid orderId)
        {
            return Ok();
        }

        




    }
}
