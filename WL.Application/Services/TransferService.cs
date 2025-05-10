

using Microsoft.Extensions.Logging;
using WL.Application.DTO;
using WL.Application.Extensions;
using WL.Application.Services.Interfaces;
using WL.Data.Results;
using WL.Data.UnitOfWork.Interfaces;
using WL.Domain.Entities;

namespace WL.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IUnityOfWork _work;
        private readonly ILogger<TransferService> _logger;
        public TransferService(IUnityOfWork work, ILogger<TransferService> logger)
        {
            _work = work;
            _logger = logger;
        }

        public async Task<Result<Transfer>> Transfer(TransferDTO transfer, Guid uid, Guid uidReceptor, Guid idWalletReceptor)
        {
            var userReceptingName = await _work.UserRepository.GetNameById(uidReceptor);
            if(string.IsNullOrEmpty(userReceptingName))
            {
                return Result<Transfer>.Failure("Recepting user not exist");
            }

            var authenticity = await VerifyIsOfMyAccount(transfer.idWalletCreator, uid);
            if (authenticity.IsSuccess)
            {
                var authorizeBalance = await VerifyBalanceRequested(transfer.idWalletCreator, uid, transfer.amount);
                if (authorizeBalance.IsSuccess)
                {
                   Transfer transfered = new(uid, uidReceptor, DateTime.UtcNow, transfer.amount, transfer.idWalletCreator, transfer.idWalletReceptor, userReceptingName);
                    var result = await _work.TransferRepository.Create(transfered);
                   if(result == null)
                   {
                       return Result<Transfer>.Failure("Error on made your requesting, try again later");
                   }
                   
                    return Result<Transfer>.Success(transfered);
                }
                return Result<Transfer>.Failure("Verify your balance and the amount sending.");
            }
            return Result<Transfer>.Failure("Authenticity not assigned");
        }

        public async Task<IEnumerable<TransferDTO>> Transfers(DateOnly? byDate, Guid uid)
        {
             return MapperTransfer.ToEnumerableTransferDTO(await _work.TransferRepository.GetByDate(byDate, uid));
        }

        private async Task<Result<bool>> VerifyIsOfMyAccount(Guid idWallet, Guid uid)
        {
            // Verificando
            var wallet = await _work.WalletRepository.GetById(idWallet);
            if (wallet == null)
            {
                return Result<bool>.Failure("This wallet dont exist");
            }
            if (wallet.UserId != uid)
            {
                return Result<bool>.Failure("This wallet dont exist - ER 32");
            }
            return Result<bool>.Success(true);
        }
        private async Task<Result<bool>> VerifyBalanceRequested(Guid idWallet, Guid uid, decimal balanceRequested)
        {
            // Verificando
            var wallet = await _work.WalletRepository.GetById(idWallet);
            if (wallet == null)
            {
                return Result<bool>.Failure("This wallet dont exist");
            }
            if (wallet.UserId != uid)
            {
                return Result<bool>.Failure("This wallet dont exist - ER 32");
            }
            if (wallet.GetBalance() < 0)
            {
                return Result<bool>.Failure("Insuficient cash.");
            }
            if ((wallet.GetBalance() - balanceRequested < 0))
            {
                return Result<bool>.Failure("Insuficient cash.");
            }
          
            return Result<bool>.Success(true);
        }
    }
}
