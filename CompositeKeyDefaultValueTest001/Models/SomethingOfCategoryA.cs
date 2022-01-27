namespace CompositeKeyDefaultValueTest001.Models
{
    public class SomethingOfCategoryA
    {
        public int SomethingId { get; set; }
        public string Name { get; set; }

        public virtual Something Something { get; set; }
    }
}
