using System;
using OrderCase.Model.Entities;

namespace OrderCase.Model.RequestModels
{
    public class UpdateDto
    {
        // public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Adress Address { get; set; }
        public Product Type { get; set; }
    }
}