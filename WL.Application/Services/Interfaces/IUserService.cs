
using WL.Application.DTO;
using WL.Application.Model;
using WL.Data.Results;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<User>> RegisterNormalUser(NormalUserDTO user);
        Task<User?> Login(LoginModel login);
    }
}
