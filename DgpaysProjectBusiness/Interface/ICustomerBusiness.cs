using DgpaysProject.Core.Repository.Entity.Issuing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProjectBusiness.Interface
{
    public interface ICustomerBusiness
    {
        List<Customer> GetAll();
        Customer GetById(int id);
    }
}
