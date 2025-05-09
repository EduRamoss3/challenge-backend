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

        public async Task<Transfer> Create(Guid uidReceptor, decimal amount, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
