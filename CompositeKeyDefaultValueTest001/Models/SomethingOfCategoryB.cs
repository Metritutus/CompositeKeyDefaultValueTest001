namespace CompositeKeyDefaultValueTest001.Models
{
    public class SomethingOfCategoryB
    {
        public int SomethingId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual Something Something { get; set; }
    }
}
