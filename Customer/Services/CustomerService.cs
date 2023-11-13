using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.Model.ErrorModels;
using Core.Model.RequestModel;
using Customer.MessageQ;
using Customer.Model.Entities;
using Customer.Model.RequestModels;
using Customer.Repository;

namespace Customer.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessageProducer _messageProducer;

        public CustomerService(ICustomerRepository customerRepository, IMessageProducer messageProducer)
        {
            _customerRepository = customerRepository;
            _messageProducer = messageProducer;
        }


        public async Task<CustomerModel> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) // todo: tek if içinde çözülebilir sanki. 
            {
                throw new CustomException(HttpStatusCode.NotFound,"Customers not found");
            }                   
            if (customer.IsDeleted)    
            {
                throw new CustomException(HttpStatusCode.NotFound, "Customers not found");
            }
            _messageProducer.SendMessage(id);// Json yollamak her zamna
            
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
            // // Todo : bu parantez içindeki kısımı harici bir metod yapılıp yapılabilir. yada direk getById koysamda olur sanki
            
            // var customer =  _customerRepository.GetByIdAsync(guid);
            // if (customer == null) // todo: tek if içinde çözülebilir sanki. 
            // {
            //     throw new CustomException(HttpStatusCode.NotFound,"Customers not found");
            // }                   
            // if (customer.IsDeleted)    
            // {
            //     throw new CustomException(HttpStatusCode.NotFound, "Customers not found");
            // }
            _messageProducer.SendMessage(guid);
            return _customerRepository.Delete(guid);
        }

        public void SoftDelete(Guid guid, SoftDeleteDto softDeleteDto)
        {
            _messageProducer.SendMessage(guid);
            _customerRepository.SoftDelete(guid,softDeleteDto);
        }
    }
}