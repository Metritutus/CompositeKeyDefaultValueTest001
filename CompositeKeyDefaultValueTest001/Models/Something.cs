using System.Collections.Generic;

namespace CompositeKeyDefaultValueTest001.Models
{
    public class Something
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual SomethingOfCategoryA SomethingOfCategoryA { get; set; }
        public virtual SomethingOfCategoryB SomethingOfCategoryB { get; set; }
    }
}
