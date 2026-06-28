using BookStore_Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Data_Layer.Data
{
    public class BookStoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Data Source=.\\SQLEXPRESS;Integrated Security=True;TrustServerCertificate=True;Database=BookStoreDB;"
);
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ORDERDETAIL> ORDERDETAIL { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("Author").HasKey(a => a.AuthorID);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasColumnName("AuthorName");

            modelBuilder.Entity<Book>().ToTable("Book").HasKey(b => b.BookID);
            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorID);
            modelBuilder.Entity<Book>().HasOne(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryID);

            modelBuilder.Entity<Category>().ToTable("category").HasKey(c => c.CategoryID);
            modelBuilder.Entity<Category>().Property(c => c.CName).HasColumnName("CName");

            modelBuilder.Entity<Customer>().ToTable("customers").HasKey(c => c.CustomerID);

            modelBuilder.Entity<ORDERDETAIL>().ToTable("ORDERDETAIL").HasKey(o => o.ORDERDETAILID);
            modelBuilder.Entity<ORDERDETAIL>().HasOne(o => o.Book).WithMany(b => b.ORDERDETAIL).HasForeignKey(o => o.BookID);
            modelBuilder.Entity<ORDERDETAIL>().HasOne(o => o.Customer).WithMany(c => c.ORDERDETAIL).HasForeignKey(o => o.CustomerID);
        }

    
    }
}
