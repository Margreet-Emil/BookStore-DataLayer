public class Author
{
    public int AuthorID { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();

  
}