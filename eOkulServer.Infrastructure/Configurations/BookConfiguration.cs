using eOkulServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOkulServer.Infrastructure.Configurations;
internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasIndex(x => new { x.Title, x.Author }).IsUnique();
        builder.Property(p => p.Title).HasColumnType("varchar(100)");
        builder.Property(p => p.Summary).HasColumnType("varchar(500)");
        builder.Property(p => p.Author).HasColumnType("varchar(30)");
        builder.HasQueryFilter(filter => filter.IsDelete == false);
    }
}