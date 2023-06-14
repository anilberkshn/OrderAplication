using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.Model.ErrorModels;
using Core.Model.RequestModel;
using OrderCase.HttpClient;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;
using OrderCase.Repository;

namespace OrderCase.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderHttpClient _orderHttpClient;
        
        
        public OrderService(IOrderRepository orderRepository, IOrderHttpClient orderHttpClient)
        {
            _orderRepository = orderRepository;
            _orderHttpClient = orderHttpClient;
        }


        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            
            if (order == null)
            {
               throw new CustomException(HttpStatusCode.NotFound,"Sipariş bulunamadı.");
            }                   
            if (order.IsDeleted)    
            {
                throw new CustomException(HttpStatusCode.NotFound, "Sipariş bulunamadı.");
            }
            
            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return  await _orderRepository.GetAllAsync();
        }
      
        public async Task<IEnumerable<OrderModel>> GetAllSkipTakeAsync(GetAllDto getAllDto)
        {
            if (getAllDto.skip < 0)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Skip cannot negative");
            }

            if (getAllDto.take is > 100 or < 0)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "TooManyRequest or cannot negative");
            }
            return await _orderRepository.GetAllSkipTakeAsync(getAllDto);
        }

        public async Task<Guid> InsertAsync(OrderModel orderModel)
        {
            var customerId = await _orderHttpClient.GetCustomerFromCustomerApi(orderModel.CustomerId);
            if (customerId == Guid.Empty && customerId != orderModel.CustomerId)
            {
                throw new CustomException(HttpStatusCode.NotFound, "CustomerId bulunamadı. ");
            }

            return await _orderRepository.InsertAsync(orderModel);
        }

        public async Task<OrderModel> Update(Guid guid, UpdateDto updateDto)
        {
            return await _orderRepository.Update(guid,updateDto);
        }

        public Guid Delete(Guid guid)
        {
            return _orderRepository.Delete(guid);
        }

        public void SoftDelete(Guid guid,SoftDeleteDto softDeleteDto)
        {
            _orderRepository.SoftDelete(guid,softDeleteDto);
        }
    }
}