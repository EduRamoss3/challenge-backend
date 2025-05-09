
using Microsoft.EntityFrameworkCore;
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Data.Repository
{
    public class WalletRepository : Generic<Wallet>,IWallet
    {
        public WalletRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Wallet> Create(Wallet wallet)
        {
            try
            {
                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync();
                return wallet;
            }
            catch(Exception x)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(x.Message + "| Wallet Repository |" + "On date =" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                return null;
            }
        }
        public async Task<Wallet?> SearchWallet(Guid uid, Guid idWallet)
        {
           return await _context.Wallets.AsNoTracking().Where(p => p.UserId == uid && p.Id == idWallet).SingleOrDefaultAsync();

        }
    }
}
