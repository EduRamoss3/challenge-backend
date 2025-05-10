using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Application.DTO
{
    public class ResultTransfers
    {
        public Guid IdWalletCreator { get;  }
        public Guid IdWalletReceptor { get;  }
        public DateTime Date { get; }
        public decimal Amount { get; } 
        public string NameUserRecepting { get; }
        public ResultTransfers(Guid idWalletCreator, Guid idWalletReceptor, DateTime date, decimal amount, string nameUserRecepting)
        {
            IdWalletCreator = idWalletCreator;
            IdWalletReceptor = idWalletReceptor;
            Date = date;
            Amount = amount;
            NameUserRecepting = nameUserRecepting;
        }
    }
}
