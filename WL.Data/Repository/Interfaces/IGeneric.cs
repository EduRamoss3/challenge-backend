using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Data.Repository.Interfaces
{
    public interface IGeneric<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
