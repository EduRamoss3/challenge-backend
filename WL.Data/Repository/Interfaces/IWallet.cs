using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Data.Repository.Interfaces
{
    public interface IWallet : IGeneric<Wallet>
    {
        Task<Wallet> Create(Wallet wallet);
        Task<Wallet?> SearchWallet(Guid uid, Guid idWallet);
        Task<Wallet?> Update(Guid walletId, decimal amount);
    }
}
