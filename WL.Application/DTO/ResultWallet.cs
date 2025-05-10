using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Application.DTO
{
    public class ResultWallet
    {
        public Guid IdWallet { get; }
        public decimal Amount { get; }
        public ResultWallet(Guid idWallet, decimal amount)
        {
            IdWallet = idWallet;
            Amount = amount;
        }

    
    }
}
