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
    public class UserRepository : Generic<User>, IUser
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
