using System;
using System.Collections;
using P2WebMVC.Models.DomainModels;
using P2WebMVC.Models.JunctionModels;

namespace P2WebMVC.Models.ViewModels;

public class CartView
{

public Cart? Cart {get;set;}

public ICollection <CartProduct> Products {get;set;}=[];


}
