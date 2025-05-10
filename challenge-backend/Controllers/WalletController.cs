using challenge_backend.Extensions;
using challenge_backend.Helper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WL.Application.DTO;
using WL.Application.Extensions;
using WL.Application.Services;
using WL.Application.Services.Interfaces;
using WL.Data.Repository.Interfaces;
using WL.Domain.Entities;

namespace challenge_backend.Controllers
{
    [Authorize]
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
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<ResultWallet?>>> GetAll()
        {
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Wallet do not match");

            var wallets = await _walletService.GetAll(authenticatedUserId.GetValueOrDefault());
            return wallets.Count() > 0 ? Ok(wallets) : NoContent();
        }
        [HttpPatch]
        [Route("update-balance")]
        public async Task<ActionResult<decimal>> UpdateBalance(Guid idWallet, [Range(0.1, double.MaxValue, ErrorMessage = "The amount needs to be greater than zero")] decimal amount)
        {
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Wallet do not match");

            var result = await _walletService.UpdateAfterVerifyAuthenticity(authenticatedUserId.Value, idWallet, amount);
            if (!result.IsSuccess)
            {
                return Problem(
              detail: result.Error,
              instance: HttpContext.Request.Path,
              statusCode: 404,
              title: "Not founded",
              type: "https://httpstatuses.com/404");
            }
            return Created($"api/v1/Wallet/update-balance?amount={result.Value.amount}&idWallet={idWallet}",result.Value);
        }
        [HttpGet]
        [Route("get-balance")]
        public async Task<ActionResult<decimal>> GetBalance(Guid idWallet)
        {
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Wallet do not match");

            var balance = await _walletService.GetBalanceAfterVerifyAuthenticity(authenticatedUserId.Value, idWallet);
            if (!balance.IsSuccess)
            {
                return Problem(
              detail: balance.Error,
              instance: HttpContext.Request.Path,
              statusCode: 404,
              title: balance.Error,
              type: "https://httpstatuses.com/400");
            }
            return Ok(balance.Value);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ResultWallet>> Create([Range(0.1, double.MaxValue, ErrorMessage = "The amount needs to be greater than zero")]decimal amount)
        {
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Authenticate first");
           
            var result = await _walletService.Create(authenticatedUserId.Value, amount);

            if (!result.IsSuccess)
            {
                return Problem(
           detail: result.Error,
           instance: HttpContext.Request.Path,
           statusCode: 400,
           title: result.Error,
           type: "https://httpstatuses.com/400");
            }
            if(result.Value == null)
            {
                return  Problem(
          detail: result.Error,
          instance: HttpContext.Request.Path,
          statusCode: 400,
          title: result.Error + " Try again later.",
          type: "https://httpstatuses.com/400");
            }

            return Created($"api/wallet?id={result.Value.IdWallet}", result.Value);
        }
    }
}
