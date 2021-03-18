using DgpaysProject.Core.Repository.DataAccess;
using DgpaysProject.Core.Repository.Entity.Transaction;
using DgpaysProject.Core.Repository.Interface.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProject.Core.Repository.Repository.Transaction
{
    public class TransactionDeclineRepository:EntityRepositoryBase<TransactionDecline,DgpaysContext>,
        ITransactionDeclineRepository
    {
    }
}
