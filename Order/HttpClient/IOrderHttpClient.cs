using System;
using System.Threading.Tasks;
using OrderCase.Model.Entities;

namespace OrderCase.HttpClient
{
    public interface IOrderHttpClient
    {
        public Task<Guid> GetCustomerFromCustomerApi(Guid customerId);
        public Task<OrderModel> CheckCustomerIdOrderModel(Guid id);
        public Task <bool> CheckCustomerId(Guid id);
    }
}