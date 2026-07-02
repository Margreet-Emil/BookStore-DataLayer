using BookStore_Data_Layer.Data;
using Microsoft.EntityFrameworkCore;

using var context = new BookStoreContext();
context.Database.EnsureCreated();

Console.WriteLine("Database created successfully!");

//5

Console.WriteLine("it's 5");
var top3Books = context.ORDERDETAIL
    .Include(o => o.Book)
    .GroupBy(o => o.BookID)
    .Select(g => new
    {
        BookTitle = g.First().Book.Title,
        TotalSold = g.Sum(o => o.Quantity)
    })
    .OrderByDescending(x => x.TotalSold)
    .Take(3)
    .ToList();

foreach (var book in top3Books)
{
    Console.WriteLine($"Book name: {book.BookTitle} - Total Sold: {book.TotalSold}");
}
//6
Console.WriteLine("it's 6");
var customerPurchases = context.ORDERDETAIL
    .Include(o => o.Customer)
    .GroupBy(o => o.CustomerID)
    .Select(g => new
    {
        CustomerName = g.First().Customer.FirstName + " " + g.First().Customer.LastName,
        TotalPurchases = g.Count()
    })
    .OrderByDescending(x => x.TotalPurchases)
    .ToList();

foreach (var customer in customerPurchases)
{
    Console.WriteLine($"Customer: {customer.CustomerName} - Purchases: {customer.TotalPurchases}");
}
// 7
Console.WriteLine("it's 7");

var categories = context.Books
    .GroupBy(b => b.CategoryID)
    .Where(g => g.Count() > 5)
    .Select(g => new
    {
        CategoryID = g.Key,
        BookCount = g.Count()
    })
    .ToList();

foreach (var cat in categories)
{
    Console.WriteLine($"CategoryID: {cat.CategoryID} - Books: {cat.BookCount}");
}

// 8
Console.WriteLine("it's 8");
var avgPrice = context.Books.Average(b => b.Price);
var expensiveBooks = context.Books
    .Where(b => b.Price > avgPrice)
    .ToList();

foreach (var book in expensiveBooks)
{
    Console.WriteLine($"Book: {book.Title} - Price: {book.Price}");
}

// 9
Console.WriteLine("it's 9");
var noPurchaseCustomers = context.Customers
    .Where(c => !context.ORDERDETAIL.Any(o => o.CustomerID == c.CustomerID))
    .ToList();

if (!noPurchaseCustomers.Any())
{
    Console.WriteLine("All customers have already made a purchase.");
}
else
{
    foreach (var customer in noPurchaseCustomers)
    {
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
    }
}

// 10
Console.WriteLine("it's 10");
var revenueByMonth = context.ORDERDETAIL
    .Include(o => o.Book)
    .GroupBy(o => o.OrderID)
    .Select(g => new
    {
        OrderID = g.Key,
        Revenue = g.Sum(o => o.Quantity * o.UnitPrice)
    })
    .ToList();

foreach (var item in revenueByMonth)
{
    Console.WriteLine($"OrderID: {item.OrderID} - Revenue: {item.Revenue:C}");
}
string keyword = "harry"; 
var results = context.Books
    .Where(b => b.Title.ToLower().Contains(keyword.ToLower()))
    .AsNoTracking()
    .ToList();

foreach (var book in results)
    Console.WriteLine($"{book.BookID} - {book.Title}");

int pageNumber = 1; 
int pageSize = 10;

var pagedBooks = context.Books
    .OrderBy(b => b.Title)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .AsNoTracking()
    .ToList();

foreach (var book in pagedBooks)
    Console.WriteLine($"{book.BookID} - {book.Title}");

// ADD
Console.WriteLine(" 11 - add new book");

var newBook = new Book
{
    Title = "Clean Code",
    Price = 39.99m,
    Stock = 50,
    AuthorID = 4,
    CategoryID = 1
    
};
context.Books.Add(newBook);
context.SaveChanges();
foreach (var book1 in context.Books)
{
    Console.WriteLine($"book title: {newBook.Title} - Price: {newBook.Price}");
}


// UPDATE PRICE
Console.WriteLine(" 12 - update price");
var bookToUpdate = context.Books.FirstOrDefault(b => b.BookID == newBook.BookID);
if (bookToUpdate != null)
{
    bookToUpdate.Price = 40.5m;
    context.SaveChanges();
}
    Console.WriteLine($"Updated: {bookToUpdate.Title} - New Price: {bookToUpdate.Price}");


// DELETE
Console.WriteLine(" 13 - delete book");
var bookToDelete = context.Books.FirstOrDefault(b => b.BookID == newBook.BookID);
if (bookToDelete != null)
{
    context.Books.Remove(bookToDelete);
    context.SaveChanges();
}
    Console.WriteLine($"Deleted: {bookToDelete.Title} - ID: {bookToDelete.BookID}");

    // 14
    Console.WriteLine(" 14 - view orders");
    var orders = context.Orders
        .Include(od => od.ORDERDETAIL)
        .ThenInclude(d => d.Book)
        .AsNoTracking()
        .ToList();

    foreach (var order in orders)
    {
        Console.WriteLine($"OrderID: {order.Id} - Details count: {order.ORDERDETAIL.Count} - Revenue: {order.ORDERDETAIL.Sum(d => d.Quantity * d.UnitPrice)}");
    }

Console.WriteLine("orderdetails");
var check = context.ORDERDETAIL.ToList();
    foreach(var d in check)
    Console.WriteLine($"ID: { d.ORDERDETAILID} - quantity: { d.Quantity} - unitprice: {d.UnitPrice}");

    //15
    Console.WriteLine(" 15 - view books and order details");
var orderdetail = context.Orders
    .Include(o => o.ORDERDETAIL) 
    .ThenInclude(od => od.Book)
    .AsNoTracking()
    .ToList();

     
foreach (var d in orderdetail)
    {
    Console.WriteLine($"QUANTITY: {d.ORDERDETAIL.Count} - BOOK {d.Id} ");
    }

