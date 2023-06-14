using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Model.RequestModel;
using Customer.Model.Entities;
using Customer.Model.RequestModels;

namespace Customer.Repository
{
    public interface ICustomerRepository
    {
        public Task<CustomerModel> GetByIdAsync(Guid id);
        public Task<IEnumerable<CustomerModel>> GetAllAsync();
        public Task<IEnumerable<CustomerModel>> GetAllSkipTakeAsync(GetAllDto getAllDto);
        public Task<Guid> InsertAsync(CustomerModel customerModel);
        public Task<CustomerModel> Update(Guid id, UpdateDto updateDto);
        public Guid Delete(Guid guid);
        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto);
    }
}