using System;
using Core.Model.Entities;

namespace Customer.Model.Entities
{
    public class CustomerModel : GenericDocument
    { 
        public string Name  { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
              
    }
}