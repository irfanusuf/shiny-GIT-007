using System;
using System.ComponentModel.DataAnnotations;
using P2WebMVC.Models.DomainModels;

namespace P2WebMVC.Models;

public class User
{

    [Key]
    public  Guid UserId {get;set;} = Guid.NewGuid();
    public required string  Username {get ;set;}
    public required string  Email {get ;set;}
    public required string  Password {get ;set;}
    public string?  ProfilePicUrl {get ;set;}
    public string? Phone {get; set ; }
    public Address? Address  {get; set ; }   //  navigation property 
    public Cart?  Cart {get;set;}    // navigation property

    public ICollection<Order>? Orders {get;set;} =[]; // navigation property //  collection of orders placed by the user

   




}
