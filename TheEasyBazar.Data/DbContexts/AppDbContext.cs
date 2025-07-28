using Microsoft.EntityFrameworkCore;
using TheEasyBazar.Domain.Entities;

namespace TheEasyBazar.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}