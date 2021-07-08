namespace Wpf_library.Domain.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public int Remaining { get; set; }
    }
}