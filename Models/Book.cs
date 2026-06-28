public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int AuthorID { get; set; }
    public Author Author { get; set; } = null!;
    public int CategoryID { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ORDERDETAIL> ORDERDETAIL { get; set; } = new List<ORDERDETAIL>();
}