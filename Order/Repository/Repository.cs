using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using OrderCase.Database;
using OrderCase.Database.Interface;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;

namespace OrderCase.Repository
{
    public class Repository: GenericRepository<Order>, IRepository
    {
        public Repository(IContext context, string collectionName = "Order ") : base(context, collectionName)
        {
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var order = await FindOneAsync(x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Guid> InsertAsync(Order order)
        {
            return await CreateAsync(order);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            var update = Builders<Order>.Update
                .Set(x => x.Quantity, updateDto.Quantity)
                .Set(x => x.Price, updateDto.Price)
                .Set(x => x.Status, updateDto.Status)
                .Set(x => x.Address, updateDto.Address)
                .Set(x => x.Product, updateDto.Type);

            Update(x => x.Id == guid, update);
        }

        public Guid Delete(Guid guid)
        {
          return  Delete(x => x.Id == guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            var softDelete  = Builders<Order>.Update
                    .Set(x => x.DeleteTime, softDeleteDto.DeletedTime)
                    .Set(x => x.IsDeleted, softDeleteDto.IsDeleted)
                ;

            SoftDelete(x => x.Id == guid, softDelete);
        }
    }
}