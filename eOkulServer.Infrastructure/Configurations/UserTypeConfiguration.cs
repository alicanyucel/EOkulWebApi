using eOkulServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOkulServer.Infrastructure.Configurations;
internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasQueryFilter(filter => filter.IsDelete == false);
    }
}
