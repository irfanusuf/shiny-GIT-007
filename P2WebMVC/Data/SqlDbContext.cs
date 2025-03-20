using System;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Models;

namespace P2WebMVC.Data;

public class SqlDbContext : DbContext
{

public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

//entities

public DbSet<User> Users {get; set; }


}
