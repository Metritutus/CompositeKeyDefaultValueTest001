using CompositeKeyDefaultValueTest001.Models;
using System.Collections.Generic;

namespace CompositeKeyDefaultValueTest001.SeedData
{
    public static partial class SeedData
    {
        public static IEnumerable<Category> Categories
        {
            get
            {
                yield return new Category()
                {
                    Id = Models.Categories.A,
                    Name = nameof(Models.Categories.A)
                };
                yield return new Category()
                {
                    Id = Models.Categories.B,
                    Name = nameof(Models.Categories.B)
                };
                yield return new Category()
                {
                    Id = Models.Categories.C,
                    Name = nameof(Models.Categories.C)
                };
            }
        }
    }
}
