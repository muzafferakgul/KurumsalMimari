using DgpaysProject.Core.Repository.DataAccess;
using DgpaysProject.Core.Repository.Entity.Acquiring;
using DgpaysProject.Core.Repository.Interface.Acquiring;

namespace DgpaysProject.Core.Repository.Repository.Acquiring
{
    public class MerchantMasterRepository:EntityRepositoryBase<MerchantMaster,DgpaysContext>,
        IMerchantMasterRepository
    {
    }
}
