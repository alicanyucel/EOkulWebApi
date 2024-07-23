using eOkulServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOkulServer.Infrastructure.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Name).HasColumnType("varchar(50)");
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasQueryFilter(filter => filter.IsDelete == false);
    }
}
