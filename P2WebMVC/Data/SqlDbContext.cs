using System;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Models;
using P2WebMVC.Models.DomainModels;
using P2WebMVC.Models.JunctionModels;

namespace P2WebMVC.Data;

public class SqlDbContext : DbContext
{

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    //entities

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }


    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>()
        .HasOne(a => a.Buyer)   
        .WithOne(b => b.Address)
        .HasForeignKey<Address>(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict); //  cascade delete


        modelBuilder.Entity<Cart>()
        .HasOne(c => c.Buyer)
        .WithOne(b => b.Cart)
        .HasForeignKey<Cart>(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


        modelBuilder.Entity<Order>()
        .HasOne(o => o.Buyer)      // every order belongs to the single user
        .WithMany(b => b.Orders)   // user can have many orders
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete



        modelBuilder.Entity<CartProduct>()
        .HasKey(cp => new { cp.CartId, cp.ProductId }); // composite key


        modelBuilder.Entity<CartProduct>()
        .HasOne(cp => cp.Cart)
        .WithMany(c => c.Products) // cart can have many products
        .HasForeignKey(cp => cp.CartId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


        modelBuilder.Entity<CartProduct>()
        .HasOne(cp => cp.Product)       // every carTproduct is having product with many carts having the same product
        .WithMany(p => p.ProductsInCarts)
        .HasForeignKey(cp => cp.ProductId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete




        modelBuilder.Entity<OrderProduct>()
        .HasKey(op => new { op.OrderId, op.ProductId }); // composite key


        modelBuilder.Entity<OrderProduct>()
        .HasOne(op => op.Order)
        .WithMany(o => o.Products)
        .HasForeignKey(op => op.OrderId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        modelBuilder.Entity<OrderProduct>()
        .HasOne(op => op.Product)       // every orderproduct is having product with many orders having the same product
        .WithMany(p => p.ProductsInOrders)
        .HasForeignKey(op => op.ProductId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete




    }






}
