using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using static Customer.Model.Entities.Customer;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Customers = Customer.Model.Entities.Customer;

namespace ProjectTester
{
    [TestClass]
    public class Tests
    {
        [Test]
        public void GetByIdTest()
        {
            var mockRepository = new Mock<IRepository>();
            var customer = new global::Customer.Model.Entities.Customer
            {
                Id = Guid.Parse("95632ff5-5f05-44cf-bff6-8d44d9057cc5"),
                Name = "Ahmet",
                Email = "ahmet@absdk.com"
                
            };
            // mockRepository.Setup(x => x.GetByIdAsync(customer.Id)).Returns(new Customers()
            // {
            //     Id = customer.Id,
            //     Name = customer.Name,
            //     Address = customer.Address,
            //     CreatedTime = customer.CreatedTime,
            //     DeleteTime = customer.DeleteTime,
            //     Email = customer.Email,
            //     IsDeleted = customer.IsDeleted,
            //     UpdatedTime = customer.UpdatedTime,
            //
            // });
            var Service = new Customers();
        }
        [Test]
        public void GetByIdTestOrder()
        {
            var mockRepository = new Mock<I>();
            var order = new order
            {
                
            };
            mockRepository.Setup(x => x.GetByIdAsync(customer.Id)).Returns(new Customers()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                CreatedTime = customer.CreatedTime,
                DeleteTime = customer.DeleteTime,
                Email = customer.Email,
                IsDeleted = customer.IsDeleted,
                UpdatedTime = customer.UpdatedTime,

            });
            var Service = new Customers();
        }
    }
}