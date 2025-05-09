using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Data.Repository.Interfaces
{
    public interface IUser
    {
        Task<User?> Register(User user); 
        Task<User?> AcceptToLogin(string email, string password);
    }
}
