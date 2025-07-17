using System;

namespace P5_WebApi.Models;

public class Product
{

    public Guid ProductId { get; set; } = Guid.NewGuid();
    public required string ProductName { get; set; }

}
