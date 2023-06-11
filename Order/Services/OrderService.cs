using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Customer.Model.Entities;
using Customer.Model.ErrorModels;
using OrderCase.Model.Entities;
using OrderCase.Model.ErrorModels;
using OrderCase.Model.RequestModels;
using OrderCase.Repository;
using OrderCase.Services;

namespace OrderCase.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        { 
            _orderRepository = orderRepository;
        }


        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            
            if (order == null)
            {
               throw new OrderException(HttpStatusCode.NotFound,"Sipariş bulunamadı.");
            }                   
            if (order.IsDeleted)    
            {
                throw new OrderException(HttpStatusCode.NotFound, "Sipariş bulunamadı.");
            }
            
            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return  await _orderRepository.GetAllAsync();
        }

        public async Task<Guid> InsertAsync(OrderModel orderModel)
        {
            return await _orderRepository.InsertAsync(orderModel);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            _orderRepository.Update(guid,updateDto);
        }

        public Guid Delete(Guid guid)
        {
            return _orderRepository.Delete(guid);
        }

        public void SoftDelete(Guid guid,SoftDeleteDto softDeleteDto)
        {
            _orderRepository.SoftDelete(guid,softDeleteDto);
        }

        public async Task CustomerGetById(Guid id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"api/customer/GetById/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var customer = await responseMessage.Content.ReadFromJsonAsync<CustomerModel>();
                    var customerId = customer.Id;
                 
                }
                else
                {
                    throw new CustomerException(HttpStatusCode.NotFound, "CustomerId bulunamadı");
                }
            }
        }
    }
}