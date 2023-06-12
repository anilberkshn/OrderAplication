using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Database;
using Customer.Database.Interface;
using Customer.Model.Entities;
using Customer.Model.RequestModels;
using MongoDB.Driver;

namespace Customer.Repository
{
    public class CustomerRepository: GenericRepository<Model.Entities.CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(IContext context, string collectionName = "Customer") : base(context, collectionName)
        {
        }

        public async Task<Model.Entities.CustomerModel> GetByIdAsync(Guid id)
        {
            var order = await FindOneAsync(x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<Model.Entities.CustomerModel>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Guid> InsertAsync(Model.Entities.CustomerModel customerModel)
        {
            return await CreateAsync(customerModel);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            var update = Builders<Model.Entities.CustomerModel>.Update
                .Set(x => x.Name, updateDto.Name)
                .Set(x => x.Email, updateDto.Email)
                .Set(x => x.Address, updateDto.Address);
                
            Update(x => x.Id == guid, update);
        }

        public Guid Delete(Guid guid)
        {
          return  Delete(x => x.Id == guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            var softDelete  = Builders<Model.Entities.CustomerModel>.Update
                    .Set(x => x.DeleteTime, softDeleteDto.DeletedTime)
                    .Set(x => x.IsDeleted, softDeleteDto.IsDeleted)
                ;

            SoftDelete(x => x.Id == guid, softDelete);
        }
    }
}