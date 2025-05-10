using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Application.DTO
{
    public record TransferDTO(Guid idWalletCreator, Guid idWalletReceptor, decimal amount)
    {
    }
}
