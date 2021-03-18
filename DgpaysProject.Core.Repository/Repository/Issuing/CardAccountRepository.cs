using DgpaysProject.Core.Repository.DataAccess;
using DgpaysProject.Core.Repository.Entity.Issuing;
using DgpaysProject.Core.Repository.Interface.Issuing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProject.Core.Repository.Repository.Issuing
{
    public class CardTypeRepository:EntityRepositoryBase<CardType,DgpaysContext>,
        ICardTypeRepository
    {
    }
}
