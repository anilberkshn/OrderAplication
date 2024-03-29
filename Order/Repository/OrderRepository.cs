using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// using Core.Database;
// using Core.Database;
using Core.Model.RequestModel;
using Core.Repository;
using Core.Repository.Interface;
using MongoDB.Driver;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;


namespace OrderCase.Repository
{
    public class OrderRepository: GenericRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(IContext context, string collectionName = "Order ") : base(context, collectionName)
        {
        }

        public async Task<OrderModel> GetByIdAsync(Guid id) // id ile değil id model oluşturulmalıydı
        {
            var order = await FindOneAsync(x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return await GenericRepositoryGetAllAsync();
        }
        public async Task<IEnumerable<OrderModel>> GetAllSkipTakeAsync(GetAllDto getAllDto)
        {
            return await GetManyAsync(getAllDto);
        }

        public async Task<Guid> InsertAsync(OrderModel orderModel)
        {
            return await CreateAsync(orderModel);
        }

        public async Task<OrderModel> Update(Guid id, UpdateDto updateDto)
        {
            var update = Builders<OrderModel>.Update
                .Set(x => x.Quantity, updateDto.Quantity)
                .Set(x => x.Price, updateDto.Price)
                .Set(x => x.Status, updateDto.Status)
                .Set(x => x.Product, updateDto.Type);

            Update(x => x.Id == id, update);
            return await GetByIdAsync(id);
        }

        public Guid Delete(Guid id)
        {
          return  Delete(x => x.Id == id);
        }

        public void SoftDelete(Guid id, SoftDeleteDto softDeleteDto)
        {
            var softDelete  = Builders<OrderModel>.Update
                    .Set(x => x.DeleteTime, softDeleteDto.DeletedTime)
                    .Set(x => x.IsDeleted, softDeleteDto.IsDeleted)
                ;

            SoftDelete(x => x.Id == id, softDelete);
        }
        
        public StatusDto ChangeStatus(Guid id, StatusDto statusDto)
        {
            var status  = Builders<OrderModel>.Update
                    .Set(x => x.Status, statusDto.Status)
                    ;

            Update(x => x.Id == id, status);
            return statusDto;
        }

        public async Task<IEnumerable<OrderModel>> DeleteOrdersByCustomerId(Guid id)
        {
           
            return  await GetByCustomerId(id);  ;
        }
    }
}