using ExpenseTracker_API.Entities;
using ExpenseTracker_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker_API.Data;
public class ExpensesDbContext : DbContext
{
    public DbSet<User>? Users { get; set; } 
    public DbSet<Room>  Rooms { get; set; }
    public DbSet<Outlay> Outlays { get; set; }
    public ExpensesDbContext(DbContextOptions options) : base(options) { }
}
