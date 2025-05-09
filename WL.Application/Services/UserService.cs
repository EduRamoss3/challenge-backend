
using WL.Application.DTO;
using WL.Application.Services.Interfaces;
using WL.Data.Results;
using WL.Data.UnitOfWork.Interfaces;
using WL.Domain.Entities;

namespace WL.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnityOfWork _work;
        public UserService(IUnityOfWork work)
        {
            _work = work;
        }

        public async Task<User?> Login(string email, string password)
        {
           return await _work.UserRepository.AcceptToLogin(email, password);
            
        }

        public async Task<ResultServices> RegisterNormalUser(NormalUserDTO user)
        {
            var result = await _work.UserRepository.Register(user);
            ResultServices msg = new ResultServices()
            {
                _Entity = result,
                HasError = false,
            };

            if (result == null)
            {
                msg.Message = "Error in register new user";
                msg.HasError = true;
                return msg;
            }
            msg.Message = "Successfully user created!";
            return msg;
        }
    }
}
