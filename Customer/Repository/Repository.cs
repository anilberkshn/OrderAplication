using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Database;
using Customer.Database.Interface;
using Customer.Model.RequestModels;
using MongoDB.Driver;

namespace Customer.Repository
{
    public class Repository: GenericRepository<Model.Entities.Customer>, IRepository
    {
        public Repository(IContext context, string collectionName = "Customer") : base(context, collectionName)
        {
        }

        public async Task<Model.Entities.Customer> GetById(Guid id)
        {
            var order = await FindOneAsync(x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<Model.Entities.Customer>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Guid> InsertAsync(Model.Entities.Customer customer)
        {
            return await CreateAsync(customer);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            var update = Builders<Model.Entities.Customer>.Update
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
            var softDelete  = Builders<Model.Entities.Customer>.Update
                    .Set(x => x.DeleteTime, softDeleteDto.DeletedTime)
                    .Set(x => x.IsDeleted, softDeleteDto.IsDeleted)
                ;

            SoftDelete(x => x.Id == guid, softDelete);
        }
    }
}