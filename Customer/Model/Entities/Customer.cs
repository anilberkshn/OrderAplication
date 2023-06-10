using System;

namespace Customer.Model.Entities
{
    public class Customer : Document
    {
        public Customer()
        {
        }

        public Customer(Guid ıd, string name, string email)
        {
            Id = ıd;
            Name = name;
            Email = email;
        }

        public string Name  { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
              
    }
}