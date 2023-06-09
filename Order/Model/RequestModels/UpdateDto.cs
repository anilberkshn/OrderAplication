using System;
using Core.Model.Entities;
using OrderCase.Model.Entities;

namespace OrderCase.Model.RequestModels
{
    public class UpdateDto
    {
        // public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Product Type { get; set; }
    }
}