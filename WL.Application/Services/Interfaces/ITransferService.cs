
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface ITransferService
    {
        Task<Result<Transfer>> Transfer(Transfer transfer);
        Task<IEnumerable<Transfer?>> Transfers(Guid uid);
        Task<IEnumerable<Transfer?>> Transfers(DateOnly byDate);
    }
}
