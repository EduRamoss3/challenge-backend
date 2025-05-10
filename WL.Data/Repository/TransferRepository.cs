using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Domain.Entities;

namespace WL.Data.Repository
{
    public class TransferRepository : Generic<Transfer>, ITransfer
    {

        public TransferRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Transfer?> Create(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            var transferedValues = await TransferValues(transfer);
            if (transferedValues)
            {
                await _context.SaveChangesAsync();
                return transfer;
            }
            return null;
        }
        private async Task<bool> TransferValues(Transfer transfer)
        {
            var walletSending = await _context.Wallets.SingleOrDefaultAsync(p => p.UserId == transfer.UidOfCreator && p.Id == transfer.IdWalletCreator);
            if (walletSending == null) { return false; }

            var walletReceptor = await _context.Wallets.SingleOrDefaultAsync(p => p.UserId == transfer.UidOfReceptor && p.Id == transfer.IdWalletReceptor);

            if (walletReceptor == null) { return false; }

            walletSending.MakeTransfer(transfer.Amount);
            _context.Entry(walletSending).Property(p => p.Amount).IsModified = true;

            walletReceptor.SetAmount(transfer.Amount);
            _context.Entry(walletReceptor).Property(p => p.Amount).IsModified = true;

            return false;
        }
       
    }
}
