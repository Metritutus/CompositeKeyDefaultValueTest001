using Microsoft.EntityFrameworkCore;
using CompositeKeyDefaultValueTest001.ModelConfigurations;
using CompositeKeyDefaultValueTest001.Models;

namespace CompositeKeyDefaultValueTest001
{
    public class ExampleDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Something> Somethings { get; set; }
        public virtual DbSet<SomethingOfCategoryA> SomethingsOfCategoryA { get; set; }
        public virtual DbSet<SomethingOfCategoryB> SomethingsOfCategoryB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CompositeKeyDefaultValueTest001.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Something>(new SomethingConfiguration());
            modelBuilder.ApplyConfiguration<SomethingOfCategoryA>(new SomethingOfCategoryAConfiguration());
            modelBuilder.ApplyConfiguration<SomethingOfCategoryB>(new SomethingOfCategoryBConfiguration());
        }
    }
}
