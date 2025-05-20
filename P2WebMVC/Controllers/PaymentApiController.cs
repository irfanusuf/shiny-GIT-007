using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P2WebMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentApiController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> CreatePaymentIntent()
        {

           //  call payment gateway to create reciept 
            return StatusCode(402);


        }


    }
}
