
using Microsoft.Extensions.Logging;
using WL.Application.DTO;
using WL.Application.Model;
using WL.Application.Services.Interfaces;
using WL.Data.Results;
using WL.Data.UnitOfWork.Interfaces;
using WL.Domain.Entities;

namespace WL.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnityOfWork _work;
        private readonly ILogger<UserService> _logger;  
        public UserService(IUnityOfWork work, ILogger<UserService> logger)
        {
            _work = work;
            _logger = logger;
        }

        public async Task<User?> Login(LoginModel model)
        {
           return await _work.UserRepository.AcceptToLogin(model.Email, model.Password);
            
        }

        public async Task<Result<User>> RegisterNormalUser(NormalUserDTO dto)
        {
            try
            {
                var verifyIfExist = await _work.UserRepository.GetByEmail(dto.Email);
                if (verifyIfExist)
                {
                    return Result<User>.Failure("Already exist an user with this email");
                }
                var user = new User(dto.Name, dto.Email, dto.Password); 

                var result = await _work.UserRepository.Register(user);

                if (result == null)
                {
                    return Result<User>.Failure("Error in registering new user.");
                }

                return Result<User>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while registering user.");
                return Result<User>.Failure("Unexpected error occurred.");
            }
        }
    }
}
