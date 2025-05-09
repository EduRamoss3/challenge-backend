using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Data.Repository.Interfaces;

namespace WL.Data.UnitOfWork.Interfaces
{
    public interface  IUnityOfWork
    {
        IWallet WalletRepository { get; }
        ITransfer TransferRepository { get; }
        IUser UserRepository { get; }
    }
}
