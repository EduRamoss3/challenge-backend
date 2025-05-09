
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Domain.Entities;

namespace WL.Data.Repository
{
    public class WalletRepository : Generic<Wallet>,IWallet
    {
        public WalletRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Wallet> Create(Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
