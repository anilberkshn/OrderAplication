using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OrderCase.Model.Entities;
using OrderCase.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OrderCase.HttpClient
{
    public class OrderHttpClient : IOrderHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly System.Net.Http.HttpClient _httpClient;
        // private readonly ICustomerService _customerService;

        public OrderHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.CreateClient();
        }
        
        
        public async Task<Guid> GetCustomerFromCustomerApi(Guid customerId) // Guid yanlış ama doğru mantık nasıl
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5010/api/customers/{customerId}");
            // response.
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var customer = JsonSerializer.Deserialize<Guid>(json);
                return customer;
            }
            else
            {
                return Guid.Empty;
            }

        }

        public Task<OrderModel> CheckCustomerIdOrderModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckCustomerId(Guid id)
        {
            throw new NotImplementedException();
        }
        // public Task<OrderModel> CheckCustomerIdOrderModel(Guid id)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public async Task<bool> CheckCustomerId(Guid customerId)
        // {
        //     var url = $"api/customer/GetById/{customerId}";
        //     var todosJson = await _httpClient.GetStringAsync(url);
        //     var to do = Deserialize < IEnumerable<OrderModel>> (todosJson);
        //     return true;
        // }
        //
        // private T Deserialize<T>(string json)
        // {
        //     return JsonSerializer.Deserialize<T>(json);
        // }


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