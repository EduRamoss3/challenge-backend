
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

        public async Task<Result<WalletDTO>> Create(Guid uid, decimal amount)
        {
            var user = await _work.UserRepository.GetById(uid);
            if (user == null)
            {
                return Result<WalletDTO>.Failure("Can't create a wallet without an existing user.");
            }
            Wallet wallet = new(uid, amount);
            var result = await _work.WalletRepository.Create(wallet);
            if (result == null)
            {
                return Result<WalletDTO>.Failure("Verify all fields and try again later.");
            }

            return Result<WalletDTO>.Success(MapperWallet.ToDTO(result));
        }

        public async Task<IEnumerable<Wallet?>> GetAll(Guid uid)
        {
            return await _work.WalletRepository.GetAll(uid);
        }

        public async Task<Result<decimal>> GetBalanceAfterVerifyAuthenticity(Guid uid, Guid idWallet)
        {
            var verify = await VerifyIsOfMyAccount(idWallet, uid);
            if (!verify.IsSuccess)
            {
                return Result<decimal>.Failure("Not found");
            }
            var wallet = await _work.WalletRepository.SearchWallet(uid, idWallet);
            if (wallet == null)
            {
                return Result<decimal>.Failure("Wallet not found.");
            }

            var balance = wallet.GetBalance();
            return Result<decimal>.Success(balance);
        }

        public async Task<Result<WalletDTO>> UpdateAfterVerifyAuthenticity(Guid uid, Guid idWallet, decimal amount)
        {
            var verify = await VerifyIsOfMyAccount(idWallet, uid);
            if (!verify.IsSuccess)
            {
                return verify;
            }

            var user = await _work.UserRepository.GetById(uid);
            if (user == null)
                return Result<WalletDTO>.Failure("Not found");

            // Verificando se o wallet é do proprio usuario
            var wallet = await _work.WalletRepository.GetById(idWallet);

            var result = await _work.WalletRepository.Update(idWallet, amount);
            if (result == null)
                return Result<WalletDTO>.Failure("Wallet not found.");

            return Result<WalletDTO>.Success(MapperWallet.ToDTO(result));

        }
        private async Task<Result<WalletDTO>> VerifyIsOfMyAccount(Guid idWallet, Guid uid)
        {
            // Verificando
            var wallet = await _work.WalletRepository.GetById(idWallet);
            if(wallet == null)
            {
                return Result<WalletDTO>.Failure("This wallet dont exist");
            }
            if (wallet.UserId != uid)
            {
                return Result<WalletDTO>.Failure("This wallet dont exist");
            }
            return Result<WalletDTO>.Success(MapperWallet.ToDTO(wallet));
        }


    }
}
