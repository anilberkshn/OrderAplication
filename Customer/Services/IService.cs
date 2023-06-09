using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Model.RequestModels;

namespace Customer.Services
{
    public interface IService
    {
        public Customer.Model.Entities.Customer GetById(Guid id);
        
        public Task<IEnumerable<Model.Entities.Customer>> GetAllAsync();
        public Task<Guid> InsertAsync(Model.Entities.Customer customer);
        public void Update(Guid guid, UpdateDto updateDto);
        public Guid Delete(Guid guid);
        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto);
    }
}