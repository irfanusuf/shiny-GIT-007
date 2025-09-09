using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P5_WebApi.Models.JunctionModels;
using P5_WebApi.Types;




namespace P5_WebApi.Models.DomainModels;

public class Order
{

[Key]
public  Guid OrderId { get; set; } = Guid.NewGuid();

public required Guid UserId { get; set; }  // Fk 
[ForeignKey("UserId")]
public User? Buyer { get; set; }  // navigation property 



public required Guid AddressId { get; set; }  // Fk 
[ForeignKey("AddressId")]
public Address? Address { get; set; }   // navigation property


public required ICollection<OrderProduct> OrderProducts { get; set; } = []; //  collection of products in the order

public required decimal TotalPrice { get; set; } = 0;

public  DateTime DateCreated { get; set; } = DateTime.UtcNow;
public  OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
public  PaymentMode PaymentMode { get; set; } = PaymentMode.None;
public  PaymentStatus PaymentStatus { get; set; } = PaymentStatus.pending;
public  DateTime? ShippingDate { get; set; } =DateTime.UtcNow.AddDays(7);


}
