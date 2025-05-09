
using WL.Application.DTO;
using WL.Application.Services.Interfaces;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services
{
    public class UserService : IUserService
    {
        public Task<User?> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ResultServices> RegisterNormalUser(NormalUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
