using BookStore_Data_Layer.Models;

public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? city { get; set; }
    public ICollection<ORDERDETAIL> ORDERDETAIL { get; set; } = new List<ORDERDETAIL>();
}