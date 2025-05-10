
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Data.Repository
{
    public class WalletRepository : Generic<Wallet>,IWallet
    {
        private readonly ILogger<WalletRepository> _logger;
        public WalletRepository(AppDbContext context, ILogger<WalletRepository> logger) : base(context)
        {
            _logger = logger;
        }
        public async Task<Wallet?> Update(Guid id, decimal amount)
        {
            var existingWallet = await _context.Wallets.FindAsync(id);
            if(existingWallet != null)
            {
                existingWallet.SetAmount(amount);
                _context.Entry(existingWallet).Property(p => p.Amount).IsModified = true;
                await _context.SaveChangesAsync();
                return existingWallet;
            }
            return null;
        }

      
        public async Task<Wallet?> Create(Wallet wallet)
        {
            try
            {
                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync();
                return wallet;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while creating wallet.");
                return null;
            }
        }
        public async Task<Wallet?> SearchWallet(Guid uid, Guid idWallet)
        {
           return await _context.Wallets.AsNoTracking().Where(p => p.UserId == uid && p.Id == idWallet).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<Wallet?>> GetAll(Guid uid)
        {
            return await _context.Wallets.AsNoTracking().Where(p => p.UserId == uid ).ToListAsync();
        }
    }
}
