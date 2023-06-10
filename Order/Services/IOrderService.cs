using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;

namespace OrderCase.Services
{
    public interface IOrderService
    {
        public Task<OrderModel> GetByIdAsync(Guid id);
        
        public Task<IEnumerable<OrderModel>> GetAllAsync();
        public Task<Guid> InsertAsync(OrderModel orderModel);
        public void Update(Guid guid, UpdateDto updateDto);
        public Guid Delete(Guid guid);
        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto);
    }
}