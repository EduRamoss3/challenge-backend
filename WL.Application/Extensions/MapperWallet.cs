using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.DTO;
using WL.Domain.Entities;

namespace WL.Application.Extensions
{
    public static class MapperWallet
    {
        public static WalletDTO ToDTO(this Wallet wallet)
        {
            return new WalletDTO(wallet.Amount, wallet.UserId); 
        }
        
        public static IEnumerable<WalletDTO> EnumerableToDto(this IEnumerable<WalletDTO> wallet)
        {
            List<WalletDTO?> dtos = new List<WalletDTO?>();
            foreach (var item in dtos)
            {
                dtos.Add(ToDTO(item));
            }
            return dtos;
        }
        public static IEnumerable<WalletDTO?> WalletToEnumerableDTO(this IEnumerable<Wallet?> wallet)
        {
            List<WalletDTO?> wallets = new List<WalletDTO?>();
            foreach (var item in wallet)
            {
                wallets.Add(ToDTO(item));
            }
            return wallets;
        }
    }
}
