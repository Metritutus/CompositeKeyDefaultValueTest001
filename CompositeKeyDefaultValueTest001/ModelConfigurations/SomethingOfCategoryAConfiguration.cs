using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompositeKeyDefaultValueTest001.Models;

namespace CompositeKeyDefaultValueTest001.ModelConfigurations
{
    public class SomethingOfCategoryAConfiguration : IEntityTypeConfiguration<SomethingOfCategoryA>
    {
        private static string CategoryIdColumnName { get; } = "CategoryId";

        public void Configure(EntityTypeBuilder<SomethingOfCategoryA> builder)
        {
            builder.ToTable("SomethingOfCategoryA");

            builder.Property<int>(CategoryIdColumnName)
                .HasDefaultValue(Categories.A)
                .IsRequired();

            builder.HasKey(nameof(SomethingOfCategoryA.SomethingId), CategoryIdColumnName);

            builder.HasOne(d => d.Something)
                .WithOne(p => p.SomethingOfCategoryA)
                .HasPrincipalKey<Something>(p => new { p.Id, p.CategoryId })
                .HasForeignKey<SomethingOfCategoryA>(nameof(SomethingOfCategoryA.SomethingId), CategoryIdColumnName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK__SomethingOfCategoryA_SomethingId_{CategoryIdColumnName}_To_Something_Id_{CategoryIdColumnName}");

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(CategoryIdColumnName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SomethingOfCategoryA_CategoryId_To_Category_Id");
        }
    }
}
