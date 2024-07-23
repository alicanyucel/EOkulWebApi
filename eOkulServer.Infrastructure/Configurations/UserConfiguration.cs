using eOkulServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOkulServer.Infrastructure.Configurations;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(p => p.Address, builder =>
        {
            builder.Property(p => p.City).HasColumnName("City");
            builder.Property(p => p.Town).HasColumnName("Town");
            builder.Property(p => p.FullAddress).HasColumnName("FullAddress");
        });
    }
}
