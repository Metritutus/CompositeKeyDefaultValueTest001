using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompositeKeyDefaultValueTest001.Models;

namespace CompositeKeyDefaultValueTest001.ModelConfigurations
{
    public class SomethingOfCategoryBConfiguration : IEntityTypeConfiguration<SomethingOfCategoryB>
    {
        public void Configure(EntityTypeBuilder<SomethingOfCategoryB> builder)
        {
            builder.ToTable("SomethingOfCategoryB");

            builder.Property(socb => socb.CategoryId)
                .HasDefaultValue(Categories.B)
                .IsRequired();

            builder.HasKey(socb => new { socb.SomethingId, socb.CategoryId });

            builder.HasOne(d => d.Something)
                .WithOne(p => p.SomethingOfCategoryB)
                .HasPrincipalKey<Something>(p => new { p.Id, p.CategoryId })
                .HasForeignKey<SomethingOfCategoryB>(socb => new { socb.SomethingId, socb.CategoryId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SomethingOfCategoryB_SomethingId_CategoryId_To_Something_Id_CategoryId");

            builder.HasOne(socb => socb.Category)
                .WithMany()
                .HasForeignKey(socb => socb.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SomethingOfCategoryB_CategoryId_To_Category_Id");
        }
    }
}
