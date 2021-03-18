using DgpaysProject.Core.Repository.Entity.Transaction;
using DgpaysProject.Utilities.Constants;
using DgpaysProject.Utilities.Results;
using DgpaysProjectUI.Core.Repository.Model;
using System;

namespace DgpaysProjectBusiness.Concrete
{
    public partial class TransactionBusiness
    {
        TransactionMaster transactionMaster = new TransactionMaster();
        public IResult CheckTransactionType(TransactionRequest transaction)
        {
            if (transaction.TxnType == 1)
            {
                NormalTransaction(transaction);
            }
            else if (transaction.TxnType == 2)
            {
                CancelTransaction(transaction);
            }
            else
            {
                return new ErrorResult("Geçersiz işlem tipi" + Messages.InvalidTransaction);
            }

            return new SuccessResult();
        }
        public IResult NormalTransaction(TransactionRequest transaction)
        {
            try
            {
                #region Controls
                var card = CheckCard(transaction.CardNumber, transaction.Amount, transaction.TxnType);
                var merchant = CheckMerchant(transaction.MerchantId);
                var terminal = CheckTerminal(transaction.TerminalId);
                var controls = Controls(card.Success, merchant.Success, terminal.Success);
                #endregion

                #region MakeTransaction
                StartTransaction(controls.Success);
                UpdateBalance(transaction.CardNumber, transaction.Amount);
                #endregion

                #region UpdateDb
                UpdateCard(transaction.CardNumber);
                UpdateTerminal(transaction.TerminalId);
                #endregion
                return new SuccessResult(Messages.SuccessTransaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "-" + e.InnerException);
            }
        }
        public IResult CheckCard(string cardNumber, long amount, long txnType)
        {
            var card = _cardRepository.Get(c => c.CardNumber == cardNumber);
            if (card == null)
                throw new Exception("Kart numarasına ait kart bulunamadı");

            if (card == null && card.ExpiryDate < DateTime.Now && card.Balance < amount)
            {
                return new ErrorResult(Messages.InvalidTransaction);
            }
            else
            {
                transactionMaster.CardNumber = card.CardNumber;
                transactionMaster.Amount = amount;
                transactionMaster.TxnType = txnType;
                return new SuccessResult(Messages.SuccessTransaction);
            }

        }
        public IResult CheckMerchant(string merchantId)
        {
            var merchant = _merchantMasterRepository.Get(m => m.MerchantNumber == merchantId);
            if (merchant == null)
                throw new Exception("Merchant numarasına ait merchant bulunamadı");
            else
            {
                transactionMaster.MerchantNumber = merchantId;
                return new SuccessResult(Messages.SuccessTransaction);
            }

        }
        public IResult CheckTerminal(string terminalId)
        {
            var terminal = _terminalMasterRepository.Get(t => t.TerminalNumber == terminalId);
            if (terminal == null)
                throw new Exception("Terminal numarasına ait terminal bulunamadı");
            else
            {
                transactionMaster.TerminalNumber = terminalId;
                return new SuccessResult(Messages.SuccessTransaction);
            }
        }
        public IResult Controls(bool card, bool merchant, bool terminal)
        {
            if (card == true && merchant == true && terminal == true)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IResult StartTransaction(bool result)
        {
            if (result)
            {
                transactionMaster.StatusId = 1;
                Add(transactionMaster);
                return new SuccessResult(Messages.SuccessTransaction);
            }
            else
            {
                return new ErrorResult(Messages.InvalidTransaction);
            }

        }
        public IResult UpdateBalance(string cardNumber, long amount)
        {
            var card = _cardRepository.Get(c => c.CardNumber == cardNumber);
            card.Balance = card.Balance - amount;
            _cardRepository.Update(card);
            return new SuccessResult();
        }
        public IResult UpdateCard(string cardNumber)
        {
            var card = _cardRepository.Get(c => c.CardNumber == cardNumber);
            card.LastTransactionDate = DateTime.Now;
            _cardRepository.Update(card);
            return new SuccessResult();
        }
        public IResult UpdateTerminal(string terminalId)
        {
            var terminal = _terminalMasterRepository.Get(t => t.TerminalNumber == terminalId);
            terminal.LastTransactionDate = DateTime.Now;
            _terminalMasterRepository.Update(terminal);
            return new SuccessResult();
        }
        public IResult CancelTransaction(TransactionRequest transaction)
        {
            try
            {
                CheckTransactionId(transaction.MainTransactionId, transaction.TxnType);
                return new SuccessResult(Messages.SuccessTransaction);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message + Messages.InvalidTransaction);
            }

        }
        public IResult CheckTransactionId(long id, long txnType)
        {
            var transaction = _transactionMasterRepository.Get(t => t.Id == id);
            if (transaction == null)
                throw new Exception("Transaction numarasına ait transaction bulunamadı");
            else
            {
                transactionMaster = transaction;
                UpdateTerminal(transaction.TerminalNumber);
                CancelUpdateCard(transaction.CardNumber, transaction.Amount);
                transactionMaster.TxnType = txnType;
                transactionMaster.Id = 0;
                Add(transactionMaster);
                return new SuccessResult();
            }

        }
        public IResult CancelUpdateCard(string cardNumber, long amount)
        {
            var card = _cardRepository.Get(c => c.CardNumber == cardNumber);
            card.LastTransactionDate = DateTime.Now;
            card.Balance = card.Balance + amount;
            _cardRepository.Update(card);
            return new SuccessResult();
        }
    }
}
