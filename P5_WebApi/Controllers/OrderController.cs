using System;
using Microsoft.AspNetCore.Mvc;
using P5_WebApi.Data;
using P5_WebApi.Middlewares;
using P5_WebApi.Types;

namespace P5_WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]

[Authorize]
public class OrderController : ControllerBase
{

    private readonly SqlDbContext sqlDb;

    public OrderController(SqlDbContext dbContext)
    {
        sqlDb = dbContext;
    }


    [HttpGet("CreateCartOrder")]
    public ActionResult CreateCartOrder(Guid cartId)
    {
        return Ok();
    }


    [HttpGet("Cancelorder")]
    public ActionResult Cancelorder(Guid OrderId)
    {
        return Ok();
    }

    [HttpGet("UpdateOrderStatus")]
    public ActionResult UpdateOrderStatus(Guid OrderId, OrderStatus status)
    {
        return Ok();
    }

}
