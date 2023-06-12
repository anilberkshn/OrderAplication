using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Model.Entities;
using Customer.Model.RequestModels;

namespace Customer.Services
{
    public interface ICustomerService
    {
        public Task<Model.Entities.CustomerModel> GetByIdAsync(Guid id);
        
        public Task<IEnumerable<Model.Entities.CustomerModel>> GetAllAsync();
        public Task<Guid> InsertAsync(Model.Entities.CustomerModel customerModel);
        public void Update(Guid guid, UpdateDto updateDto);
        public Guid Delete(Guid guid);
        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto);
    }
}