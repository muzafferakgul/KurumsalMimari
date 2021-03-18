using DgpaysProject.Utilities.Constants;
using DgpaysProject.Utilities.Results;
using DgpaysProjectBusiness.Interface;
using DgpaysProjectUI.Core.Repository.Model;
using DgpaysProjectUI.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DgpaysProjectUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }
        [HttpPost]
        [Route("MakeTransaction")]
        [LogExample]
        public IResult MakeTransaction(TransactionRequest transaction)
        {
            try
            {
                _transactionBusiness.MakeTransaction(transaction);
                return new SuccessResult(Messages.SuccessTransaction);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message + Messages.InvalidTransaction);
            }

        }
    }
}
