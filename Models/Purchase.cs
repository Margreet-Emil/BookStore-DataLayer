using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore_Data_Layer.Models
{
   public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<ORDERDETAIL> ORDERDETAIL { get; set; } = new List<ORDERDETAIL>();
    }
}
