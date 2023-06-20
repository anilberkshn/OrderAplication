using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.Model.ErrorModels;
using Core.Model.RequestModel;
using Customer.Model.Entities;
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
                throw new CustomException(HttpStatusCode.NotFound,"Müşteri bulunamadı.");
            }                   
            if (customer.IsDeleted)    
            {
                throw new CustomException(HttpStatusCode.NotFound, "Müşteri bulunamadı.");
            }
            
            return customer;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
        public async Task<IEnumerable<CustomerModel>> GetAllSkipTakeAsync(GetAllDto getAllDto)
        {
            return await _customerRepository.GetAllSkipTakeAsync(getAllDto);
        }

        public Task<Guid> InsertAsync(CustomerModel customerModel)
        {
            return _customerRepository.InsertAsync(customerModel);
        }

        public async Task<CustomerModel> Update(Guid guid, UpdateDto updateDto)
        {
            return await _customerRepository.Update(guid,updateDto);
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