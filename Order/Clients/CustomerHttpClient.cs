using System;
using System.Net.Http;
using System.Threading.Tasks;
using OrderCase.Model.Entities;

namespace OrderCase.Clients
{
    public class CustomerHttpClient : ICustomerHttpClient
    {
        private readonly HttpClient _httpClient;
        public CustomerHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<bool> GetCustomerFromCustomerApi(Guid customerId) // Guid yanlış ama doğru mantık nasıl
        {
           var response = await _httpClient.GetAsync($"api/customers/{customerId}");
            
            if (response.IsSuccessStatusCode)
            {
                 return true;
            }
            else
            {
                return false;
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