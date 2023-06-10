using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Customer.Model.Entities;
using Customer.Model.ErrorModels;
using Customer.Model.RequestModels;
using Customer.Repository;

namespace Customer.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<CustomerModel> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            
            if (customer == null)
            {
                throw new CustomerException(HttpStatusCode.NotFound,"Müşteri bulunamadı.");
            }                   
            if (customer.IsDeleted)    
            {
                throw new CustomerException(HttpStatusCode.NotFound, "Müşteri bulunamadı.");
            }
            
            return customer;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public Task<Guid> InsertAsync(CustomerModel customerModel)
        {
            return _customerRepository.InsertAsync(customerModel);
        }

        public void Update(Guid guid, UpdateDto updateDto)
        {
            _customerRepository.Update(guid,updateDto);
        }

        public Guid Delete(Guid guid)
        {
            return _customerRepository.Delete(guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            _customerRepository.SoftDelete(guid,softDeleteDto);
        }
    }
}