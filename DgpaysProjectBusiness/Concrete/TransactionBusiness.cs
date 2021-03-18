using DgpaysProject.Core.Repository.Entity.Transaction;
using DgpaysProject.Core.Repository.Interface.Acquiring;
using DgpaysProject.Core.Repository.Interface.Issuing;
using DgpaysProject.Core.Repository.Interface.Transaction;
using DgpaysProject.Utilities.Constants;
using DgpaysProject.Utilities.Results;
using DgpaysProjectBusiness.Interface;
using DgpaysProjectUI.Core.Repository.Model;
using System;

namespace DgpaysProjectBusiness.Concrete
{
    public partial class TransactionBusiness : ITransactionBusiness
    {
        ITransactionMasterRepository _transactionMasterRepository;
        ICardRepository _cardRepository;
        ITerminalMasterRepository _terminalMasterRepository;
        IMerchantMasterRepository _merchantMasterRepository;

        public TransactionBusiness(ITransactionMasterRepository transactionMasterRepository, ICardRepository cardRepository, ITerminalMasterRepository terminalMasterRepository, IMerchantMasterRepository merchantMasterRepository)
        {
            _transactionMasterRepository = transactionMasterRepository;
            _cardRepository = cardRepository;
            _terminalMasterRepository = terminalMasterRepository;
            _merchantMasterRepository = merchantMasterRepository;
        }

        public IResult Add(TransactionMaster transactionMaster)
        {
            _transactionMasterRepository.Add(transactionMaster);
            return new SuccessResult(Messages.SuccessTransaction);
        }

        public IResult MakeTransaction(TransactionRequest transaction)
        {
            try
            {
                CheckTransactionType(transaction);
                return new SuccessResult(Messages.SuccessTransaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "-" + e.InnerException);
            }
        }
    }
}
//Validations,fluent validations
//data anotations
//enum.isDefined