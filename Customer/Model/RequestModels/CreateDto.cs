using System;
using Customer.Model.Entities;

namespace Customer.Model.RequestModels
{
    public class CreateDto
    {
        public string Name  { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}