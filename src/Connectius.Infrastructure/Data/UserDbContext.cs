using Connectius.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connectius.Infrastructure.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(x => x.Id);
            user.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(100);
            user.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);
            user.Property(x => x.Email)
                .IsRequired();
            user.Property(x => x.PasswordHash)
                .IsRequired();
        });
    }
}