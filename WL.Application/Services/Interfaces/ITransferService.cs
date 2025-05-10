
using WL.Application.DTO;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface ITransferService
    {
        Task<Result<Transfer>> Transfer(TransferDTO transfer, Guid uid, Guid uidReceptor, Guid idWalletReceptor);
        Task<IEnumerable<Transfer?>> Transfers(DateOnly byDate, Guid uid);
    }
}
