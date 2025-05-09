using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Data.Repository.Interfaces
{
    public interface ITransfer
    {
        Task<Transfer> Create(Guid uidReceptor, decimal amount, DateTime date);
    }
}
