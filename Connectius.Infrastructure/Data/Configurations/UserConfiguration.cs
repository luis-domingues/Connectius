using Connectius.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectius.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x => x.Username, x =>
        {
            x.Property(x => x.Value).HasColumnName("Username").IsRequired();
        });
        
        builder.OwnsOne(x => x.Email, x =>
        {
            x.Property(x => x.Value).HasColumnName("Email").IsRequired();
        });

        builder.OwnsOne(x => x.PhoneNumber, x =>
        {
            x.Property(x => x.Value).HasColumnName("PhoneNumber").IsRequired();
        });
        
        builder.Ignore(x => x.DomainEvents);
    }
}