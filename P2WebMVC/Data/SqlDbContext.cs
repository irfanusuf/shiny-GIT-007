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

    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>()
        .HasOne(a => a.Buyer)
        .WithOne(b => b.Address)
        .HasForeignKey<Address>(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


        modelBuilder.Entity<Cart>()
        .HasOne(c => c.Buyer)
        .WithOne(b => b.Cart)
        .HasForeignKey<Cart>(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


        modelBuilder.Entity<Order>()
        .HasOne(o => o.Buyer)
        .WithMany(b => b.Orders)
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete






    }






}
