using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.DTO;
using WL.Domain.Entities;

namespace WL.Application.Extensions
{
    public static class MapperTransfer
    {
        public static IEnumerable<TransferDTO?> ToEnumerableTransferDTO(this IEnumerable<Transfer?> _transfer)
        {
            List<TransferDTO?> transfers = new List<TransferDTO?>();
            foreach (var item in _transfer)
            {
                TransferDTO transfer = new(item.IdWalletCreator, item.IdWalletReceptor, item.Amount);
                transfers.Add(transfer);
            }
            return transfers;
        }
    }
}
