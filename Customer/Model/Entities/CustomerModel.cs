using System;

namespace Customer.Model.Entities
{
    public class CustomerModel : Document
    { 
        public string Name  { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
              
    }
}