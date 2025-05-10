using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL.Application.DTO;
using WL.Application.Services.Interfaces;
using WL.Domain.Entities;
using challenge_backend.Helper;
using Microsoft.AspNetCore.Authorization;

namespace challenge_backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromServices] ITokenService _tokenService, string email,  string password)
        {
            var result = await _userService.Login(email, password);
            if (result != null)
            {
                var token = _tokenService.GenerateToken(result);
                return Ok(token);
            }
            return Problem(
              detail: "Email and password do not match",
              instance: HttpContext.Request.Path,
              statusCode: 400,
              title: "Error of validation",
              type: "https://httpstatuses.com/400"
              );
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromServices] IValidator<NormalUserDTO> validate, NormalUserDTO user)
        {
            var validating = await validate.ValidateAsync(user);
            if (!validating.IsValid)
            {
                validating.AddToModelState(this.ModelState);

                return Problem(
                detail: string.Join(" | ", ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage)),
                instance: HttpContext.Request.Path,
                statusCode: 400,
                title: "Error of validation",
                type: "https://httpstatuses.com/400"
                );
            }

            var result = await _userService.RegisterNormalUser(user);

            if (!result.IsSuccess)
            {
                return Problem("Verify all fields and try again");
            }
            if (result.Value == null)
            {
                return Problem(result.Error);
            }
            return Created($"api/user/profile/", result.Value);
        }
    }
}
