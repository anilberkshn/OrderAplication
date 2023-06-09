using System;

namespace Customer.Model.Entities
{
    public class Customer : Document
    { 
        public string Name  { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
              
    }
}