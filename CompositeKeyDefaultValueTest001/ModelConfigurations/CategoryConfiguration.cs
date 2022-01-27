using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompositeKeyDefaultValueTest001.Models;

namespace CompositeKeyDefaultValueTest001.ModelConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasData(SeedData.SeedData.Categories);
        }
    }
}
