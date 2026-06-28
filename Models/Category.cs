
public class Category
{
    public int CategoryID { get; set; }
    public string CName { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}