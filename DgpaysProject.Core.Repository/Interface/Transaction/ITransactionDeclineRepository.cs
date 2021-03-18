using DgpaysProject.Core.Repository.DataAccess;
using DgpaysProject.Core.Repository.Entity.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProject.Core.Repository.Interface.Transaction
{
    public interface ITransactionDeclineRepository:IEntityRepository<TransactionDecline>
    {
    }
}
