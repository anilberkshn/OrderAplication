using System;
using System.Threading.Tasks;
using OrderCase.Model.Entities;

namespace OrderCase.Clients
{
    public interface ICustomerHttpClient
    {
        public Task<CustomerClientModel> GetCustomerFromCustomerApi(Guid customerId);
        public Task <bool> CheckCustomerId(Guid customerId);
    }
}