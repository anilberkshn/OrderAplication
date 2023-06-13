using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Database;
using Core.Database.Interface;
using Customer.Model.Entities;
using Customer.Model.RequestModels;
using MongoDB.Driver;

namespace Customer.Repository
{
    public class CustomerRepository: GenericRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(IContext context, string collectionName = "Customer") : base(context, collectionName)
        {
        }

        public async Task<CustomerModel> GetByIdAsync(Guid id)
        {
            var customerModel = await FindOneAsync(x => x.Id == id);
            return customerModel;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Guid> InsertAsync(CustomerModel customerModel)
        {
            return await CreateAsync(customerModel);
        }

        public async Task<CustomerModel> Update(Guid id, UpdateDto updateDto)
        {
            var update = Builders<CustomerModel>.Update
                .Set(x => x.Name, updateDto.Name)
                .Set(x => x.Email, updateDto.Email)
                .Set(x => x.Address, updateDto.Address);
                
            Update(x => x.Id == id, update);
            return await GetByIdAsync(id);
        }

        public Guid Delete(Guid guid)
        {
          return  Delete(x => x.Id == guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            var softDelete  = Builders<CustomerModel>.Update
                    .Set(x => x.DeleteTime, softDeleteDto.DeletedTime)
                    .Set(x => x.IsDeleted, softDeleteDto.IsDeleted)
                ;

            SoftDelete(x => x.Id == guid, softDelete);
        }
    }
}