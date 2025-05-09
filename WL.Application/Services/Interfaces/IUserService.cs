
using WL.Application.DTO;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultServices> RegisterNormalUser(NormalUserDTO user);
        Task<User?> Login(string email, string password);
    }
}
