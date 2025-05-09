
using Microsoft.EntityFrameworkCore;
using WL.Application.DTO;
using WL.Application.Extensions;
using WL.Application.Services.Interfaces;
using WL.Data.Repository;
using WL.Data.Repository.Interfaces;
using WL.Data.Results;
using WL.Data.UnitOfWork.Interfaces;
using WL.Domain.Entities;

namespace WL.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IUnityOfWork _work;


        public WalletService(IUnityOfWork work) 
        {
            _work = work;
        }

        public async Task<ResultServices> Create(WalletDTO dto)
        {
            ResultServices msg = new()
            {
                HasError = true,
            };
            var user = await _work.UserRepository.GetById(dto.uid);

            if(user != null)
            {
                var result = await _work.WalletRepository.Create(dto);
                if(result != null)
                {
                    msg.Message = "Wallet Successfully created!";
                    msg._Entity = dto;
                    msg.HasError = false;
                    return msg;
                }
                msg.Message = "Verify all fields and try again later!";
                msg._Entity = dto;
                msg.HasError = true;
                return msg;
            }
            else
            {
                msg._Entity = null;
                msg.HasError = true;
                msg.Message = "Can't create one wallet without existing user";
                return msg;
            }
            
            
        }

        public async Task<ResultServices> GetBalance(Guid uid, Guid idWallet)
        {
            ResultServices result = new()
            {
                HasError = false,
            };
            var wallet = await _work.WalletRepository.SearchWallet(uid, idWallet);
            if (wallet == null)
            {
                result.HasError = true;
                result.Message = "Wallet not found";
                result._Entity = null;
                return result;
            }
            result.Message = "Getting balance.";
            result._Entity = wallet.GetBalance();
            return result;
        }
    }
}
