using System;

namespace OrderCase.Model.Entities
{
    public class Order: Document
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Adress Address { get; set; }
        
        public Product Product { get; set; }
    
    }
}