using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompositeKeyDefaultValueTest001.Models;

namespace CompositeKeyDefaultValueTest001.ModelConfigurations
{
    public class SomethingConfiguration : IEntityTypeConfiguration<Something>
    {
        public void Configure(EntityTypeBuilder<Something> builder)
        {
            builder.ToTable("Something");

            builder.HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Something_CategoryId_To_Category_Id");
        }
    }
}
