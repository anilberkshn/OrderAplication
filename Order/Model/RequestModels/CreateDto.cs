using System;
using Core.Model.Entities;
using OrderCase.Model.Entities;

namespace OrderCase.Model.RequestModels
{
    public class CreateDto
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
    }
}