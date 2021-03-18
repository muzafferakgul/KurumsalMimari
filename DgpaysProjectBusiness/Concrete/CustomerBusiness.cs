using DgpaysProject.Core.Repository.Entity.Issuing;
using DgpaysProject.Core.Repository.Interface.Issuing;
using DgpaysProjectBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProjectBusiness.Concrete
{
    public class CustomerBusiness : ICustomerBusiness
    {
        ICustomerRepository _customerRepository;
        public CustomerBusiness(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.Get(c => c.Id == id);
        }
    }
}
