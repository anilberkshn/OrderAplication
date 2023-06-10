using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Customer.Model.ErrorModels;
using Customer.Model.RequestModels;
using Customer.Repository;

namespace Customer.Services
{
    public class Service: IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<Model.Entities.Customer> GetByIdAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            
            if (customer == null)
            {
                throw new CustomerException(HttpStatusCode.BadRequest,"Müşteri bulunamadı.");
            }                   
            if (customer.IsDeleted)    
            {
                throw new CustomerException(HttpStatusCode.NotFound, "Müşteri bulunamadı.");
            }
            
            return customer;
        }

        public async Task<IEnumerable<Model.Entities.Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<Guid> InsertAsync(Model.Entities.Customer customer)
        {
            return _repository.InsertAsync(customer);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            _repository.Update(guid,updateDto);
        }

        public Guid Delete(Guid guid)
        {
            return _repository.Delete(guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            _repository.SoftDelete(guid,softDeleteDto);
        }
    }
}