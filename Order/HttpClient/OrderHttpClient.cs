using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrderCase.Model.Entities;
using OrderCase.Services;

namespace OrderCase.HttpClient
{
    public class OrderHttpClient : IOrderHttpClient
    {
        private readonly IOrderService _orderService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpClientBuilder _httpClientBuilder;
        //private readonly ICustomerService _customerService;

        public OrderHttpClient(IOrderService orderService, IHttpClientFactory httpClientFactory, IHttpClientBuilder httpClientBuilder)
        {
            _orderService = orderService;
            _httpClientFactory = httpClientFactory;
            _httpClientBuilder = httpClientBuilder;
        }

        public Task<OrderModel> CheckCustomerIdOrderModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckCustomerId(Guid id)
        {
            
            return true;

        }
        
        
        // public async Task CustomerGetById(Guid id)
        // {
        //     using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
        //     {
        //         HttpResponseMessage responseMessage = await client.GetAsync($"api/customer/GetById/{id}");
        //         if (responseMessage.IsSuccessStatusCode)
        //         {
        //             var customer = await responseMessage.Content.ReadFromJsonAsync<Customer.Model.Entities.Model>();
        //             var customerId = customer.Id;
        //          
        //         }
        //         else
        //         {
        //             throw new CustomerException(HttpStatusCode.NotFound, "CustomerId bulunamadı");
        //         }
        //     }
        // }
        
        // using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
        // {
        //     HttpResponseMessage response = await client.GetAsync($"api/customer/GetById/{id}");
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var customer = await response.Content.ReadFromJsonAsync<>();
        //         var customerId = customer.CustomerId;
        //
        //            
        //     }
        //     else
        //     {
        //         return false;
        //         throw new NotImplementedException();
        //     }
        //         
        // }
        
        
        
    }
}