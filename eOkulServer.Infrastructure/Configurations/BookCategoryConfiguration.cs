using eOkulServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOkulServer.Infrastructure.Configurations;

internal sealed class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    void IEntityTypeConfiguration<BookCategory>.Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.HasIndex(x => new { x.BookId, x.CategoryId }).IsUnique();
        builder.HasQueryFilter(filter => filter.Category!.IsDelete == false);
    }
}
