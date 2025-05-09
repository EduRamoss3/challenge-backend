using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public async Task<User?> AcceptToLogin(string email, string password)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
            if (user != null && !string.IsNullOrEmpty(password))
           {
                var passwordDecoded = Criptografer.DoubleDecode(user.Password);
                if(passwordDecoded == password)
                {
                    return user;
                }
           }
            return null;
        }

        public async Task<User?> Register(User user)
        {
            try
            {
                user.Password = Criptografer.DoubleEncode(user.Password);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(Exception x)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(x.Message + "| User Repository |" + "On date =" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                return null;
            }
            
        }
    }
}
