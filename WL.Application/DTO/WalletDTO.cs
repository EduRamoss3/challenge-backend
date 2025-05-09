using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Application.DTO
{
    public record WalletDTO(decimal amount, Guid uid)
    {
        public static implicit operator Wallet(WalletDTO request)
        {
            return new Wallet(request.uid, request.amount);

        }
    }
}
