using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;

namespace OrderCase.Repository
{
    public interface IRepository
    {
        public Task<Order> GetByIdAsync(Guid id);
        public Task<IEnumerable<Order>> GetAllAsync();
        public Task<Guid> InsertAsync(Order order);
        public void Update(Guid guid, UpdateDto updateDto);
        public Guid Delete(Guid guid);
        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto);
    }
}