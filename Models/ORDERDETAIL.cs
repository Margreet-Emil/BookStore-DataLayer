using BookStore_Data_Layer.Models;

public class ORDERDETAIL
    {
        public int ORDERDETAILID { get; set; }
        public int? CustomerID { get; set; }    
        public int? OrderID { get; set; }      
        public int? Quantity { get; set; }     
        public decimal? UnitPrice { get; set; } 
        public int? BookID { get; set; }      
        public Book? Book { get; set; }
        public Customer? Customer { get; set; }
    public Purchase? Order { get; set; }
}