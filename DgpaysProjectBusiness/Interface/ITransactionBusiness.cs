using DgpaysProject.Core.Repository.Entity.Transaction;
using DgpaysProject.Utilities.Results;
using DgpaysProjectUI.Core.Repository.Model;

namespace DgpaysProjectBusiness.Interface
{
    public interface ITransactionBusiness
    {
        IResult MakeTransaction(TransactionRequest transaction);
        IResult Add(TransactionMaster transaction);
    }
}
