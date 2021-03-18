using DgpaysProject.Core.Repository.DataAccess;
using DgpaysProject.Core.Repository.Entity.Acquiring;
using DgpaysProject.Core.Repository.Interface.Acquiring;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgpaysProject.Core.Repository.Repository.Acquiring
{
    public class TerminalMasterRepository: EntityRepositoryBase<TerminalMaster, DgpaysContext>,
        ITerminalMasterRepository
    {
    }
}
