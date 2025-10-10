using Connectius.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connectius.Infrastructure.Data.Contexts;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}