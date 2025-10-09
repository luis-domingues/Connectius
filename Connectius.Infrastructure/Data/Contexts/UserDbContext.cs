using Microsoft.EntityFrameworkCore;

namespace Connectius.Infrastructure.Data.Contexts;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
}