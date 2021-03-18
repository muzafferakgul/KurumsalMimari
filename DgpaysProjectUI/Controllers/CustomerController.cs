using DgpaysProject.Core.Repository.Entity.Issuing;
using DgpaysProjectBusiness.Interface;
using DgpaysProjectUI.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DgpaysProjectUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase,ICustomerBusiness
    {
        ICustomerBusiness _customerBusiness;
        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        [HttpGet]
        [Route("GetAll")]
        [LogExample]
        public List<Customer> GetAll()
        {
            return _customerBusiness.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        [LogExample]
        public Customer GetById(int id)
        {
            return _customerBusiness.GetById(id);
        }
    }
}
