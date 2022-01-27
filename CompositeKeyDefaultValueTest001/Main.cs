using Microsoft.EntityFrameworkCore;
using CompositeKeyDefaultValueTest001.Models;
using System.Threading.Tasks;

namespace CompositeKeyDefaultValueTest001
{
    public class Main
    {
        private ExampleDbContext DbContext { get; }

        public Main(ExampleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task StartAsync()
        {
            // Migration script command:
            //dotnet ef migrations add CompositeKeyDefaultValueTest001-v1.0.0
            DbContext.Database.Migrate();

            // First test using a shadow state property for the CategoryId.
            //var newSomething = new Something() { CategoryId = 1, Name = "First" };
            //DbContext.Somethings.Add(newSomething);
            //DbContext.SaveChanges();

            //var somethingOfCategoryA = new SomethingOfCategoryA() { SomethingId = newSomething.Id, Name = "Whatever" };
            //DbContext.SomethingsOfCategoryA.Add(somethingOfCategoryA);
            //DbContext.SaveChanges();

            // Second test using a model property for the CategoryId.
            var newSomething = new Something() { CategoryId = 2, Name = "First" };
            DbContext.Somethings.Add(newSomething);
            DbContext.SaveChanges();

            var somethingOfCategoryB = new SomethingOfCategoryB() { SomethingId = newSomething.Id, Name = "Whatever" };
            DbContext.SomethingsOfCategoryB.Add(somethingOfCategoryB);
            DbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
