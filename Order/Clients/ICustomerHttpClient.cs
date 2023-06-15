using System;
using System.Threading.Tasks;
using OrderCase.Model.Entities;

namespace OrderCase.Clients
{
    public interface ICustomerHttpClient
    {
        public Task<bool> GetCustomerFromCustomerApi(Guid customerId);
        public Task<OrderModel> CheckCustomerIdOrderModel(Guid id);
        public Task <bool> CheckCustomerId(Guid id);
    }
}