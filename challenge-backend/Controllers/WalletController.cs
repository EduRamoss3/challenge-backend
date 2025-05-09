using challenge_backend.Helper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WL.Application.DTO;
using WL.Application.Services;
using WL.Application.Services.Interfaces;
using WL.Data.Repository.Interfaces;
using WL.Domain.Entities;

namespace challenge_backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        [HttpGet]
        [Route("get-balance")]
        public async Task<ActionResult<decimal>> GetBalance(Guid uid, Guid walletId)
        {
            var balance = await _walletService.GetBalance(uid, walletId);
            if (balance.HasError)
            {
                return NotFound(balance.Message);
            }
            return Ok(balance._Entity);
        }
        [HttpPost]
        [Route("create")]

        public async Task<ActionResult<WalletDTO?>> Create([FromServices] IValidator<WalletDTO> validate, WalletDTO dto)
        {
            var validating = await validate.ValidateAsync(dto);
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
            var result = await _walletService.Create(dto);

            if (result.HasError)
            {
                return Problem(result.Message);
            }
            if (result._Entity == null)
            {
                return Problem("Error creating new wallet, try again later");
            }
            return Created($"api/wallet?id={result._Entity.ToString()}", result._Entity);
        }
    }
}
