using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Customer.Model;
// using OrderCase.order.CustomerModel;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
// using Customers = CustomerModel.CustomerModel.Entities.CustomerModel;
// using Orders = Order.CustomerModel.Entities.CustomerModel;

namespace ProjectTester
{
    [TestClass]
    public class Tests
    {
        [Test]
        public void GetByIdTest()
        {
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new global::Customer.Model.Entities.CustomerModel
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
            // var CustomerService = new Customers();
        }
        [Test]
        public void GetByIdTestOrder()
        {
            // var mockRepository = new Mock<ICustomerRepository>();
            // var customer = new Customers()
            // {
            //     
            // };
            // mockRepository.Setup(x => x.GetByIdAsync(customer.Id)).Returns(new OrderCase.Order.CustomerModel.Entities.Order()
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
            // var CustomerService = new OrderCase.Order.CustomerModel.Entities.Order();
        }
    }
}