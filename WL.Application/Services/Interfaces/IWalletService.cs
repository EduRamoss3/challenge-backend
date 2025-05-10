using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.DTO;
using WL.Data.Repository.Interfaces;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface IWalletService 
    {
        Task<Result<ResultWallet>> Create(Guid uid,  decimal amount);
        Task<Result<decimal>> GetBalanceAfterVerifyAuthenticity(Guid uid, Guid idWallet);
        Task<Result<WalletDTO>> UpdateAfterVerifyAuthenticity(Guid uid, Guid idWallet, decimal amount);
        Task<IEnumerable<ResultWallet?>> GetAll(Guid uid);
        Task<Wallet?> GetById(Guid idWallet);

    }
}
