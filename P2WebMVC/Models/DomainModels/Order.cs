using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using P2WebMVC.Models.JunctionModels;
using P2WebMVC.Types;

namespace P2WebMVC.Models.DomainModels;

public class Order
{


[Key]

public required Guid OrderId { get; set; } = Guid.NewGuid();

public required Guid UserId { get; set; }  // Fk 

[ForeignKey("UserId")]
public User? Buyer { get; set; }  // navigation property 



public ICollection<OrderProduct>? Products { get; set; } = []; //  collection of products in the order


public required int Quantity { get; set; } = 1;
public required decimal TotalPrice { get; set; } = 0;




public required DateTime DateCreated { get; set; } = DateTime.UtcNow;
public required OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
public required DateTime? ShippedDate { get; set; } =DateTime.UtcNow.AddDays(7);


}
