using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using OrderCase.Model.Entities;
using OrderCase.Model.ErrorModels;
using OrderCase.Model.RequestModels;
using OrderCase.Repository;
using OrderCase.Services;

namespace OrderCase.Services
{
    public class Service: IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }


        public Order GetById(Guid id)
        {
            var order = _repository.GetById(id);
            
            if (order == null)
            {
                // hangisi daha 
                throw new OrderException(HttpStatusCode.BadRequest,"Sipariş bulunamadı.");
            }                   
            if (order.IsDeleted)    
            {
                throw new OrderException(HttpStatusCode.NotFound, "Sipariş bulunamadı.");
            }
            
            return order;
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Guid> InsertAsync(Order order)
        {
            return _repository.InsertAsync(order);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            _repository.Update(guid,updateDto);
        }

        public Guid Delete(Guid guid)
        {
            return _repository.Delete(guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            _repository.SoftDelete(guid,softDeleteDto);
        }
    }
}