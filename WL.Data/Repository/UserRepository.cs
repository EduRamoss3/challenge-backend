using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Domain.Entities;

namespace WL.Data.Repository
{
    public class UserRepository : Generic<User>, IUser
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<User?> AcceptToLogin(string email, string password)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
            if (user != null && !string.IsNullOrEmpty(password))
            {
                var passwordDecoded = Criptografer.DoubleDecode(user.Password);
                if (passwordDecoded == password)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<bool> GetByEmail(string email)
        {
           var user = await _context.Users
                                 .Where(p => p.Email.ToLower() == email.ToLower())
                                 .Select(p => p.Email)
                                 .SingleOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<string?> GetNameById(Guid id)
        {
            return await _context.Users
                                 .Where(p => p.Id == id)
                                 .Select(p => p.Name)
                                 .SingleOrDefaultAsync();
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while saving user.");
                return null;
            }

        }
    }
}
