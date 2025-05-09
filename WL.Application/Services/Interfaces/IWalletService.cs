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
        Task<ResultServices> Create(WalletDTO dto);
        Task<ResultServices> GetBalance(Guid uid, Guid idWallet);
        Task<ResultServices> UpdateBalance(Guid uid, Guid idWallet, decimal amount);

    }
}
