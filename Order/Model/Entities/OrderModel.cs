using System;
using Core.Model;
using Core.Model.Entities;
using Newtonsoft.Json;

namespace OrderCase.Model.Entities
{
    public class OrderModel: GenericDocument
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }
        

    }
}