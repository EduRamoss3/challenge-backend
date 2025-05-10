using challenge_backend.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WL.Application.DTO;
using WL.Application.Extensions;
using WL.Application.Services.Interfaces;

namespace challenge_backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        private readonly IWalletService _walletService;
        public TransferController(ITransferService transferService, IWalletService walletService)
        {
            _transferService = transferService;
            _walletService = walletService;
        }

        [HttpGet]
        [Route("get-transfers")]
        public async Task<ActionResult<IEnumerable<TransferDTO?>>> GetTransfers(DateOnly? dateBy = null)
        {
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Authenticate first");

            var transfers = await _transferService.Transfers(dateBy, authenticatedUserId.Value);
            if (transfers.Any())
            {
                return Ok(transfers);
            }
            return NoContent();
        }
        [HttpPost]
        [Route("transfer")]
        public async Task<ActionResult<TransferDTO>> Transfer ([FromBody]TransferDTO request, [FromServices] IValidator<TransferDTO> validating)
        {
            var validation = validating.Validate(request);
            if (!validation.IsValid)
            {
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
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (authenticatedUserId == null)
                return Unauthorized("Authenticate first");
            var walletReceptorInformation = await _walletService.GetById(request.idWalletReceptor);
            if (walletReceptorInformation == null)
            {
                return NotFound();
            }

            var result = await _transferService.Transfer(request, authenticatedUserId.Value, walletReceptorInformation.UserId, request.idWalletReceptor);
            if (result.IsSuccess)
            {
                ResultTransfers resultTransfer = new(result.Value.IdWalletCreator, result.Value.IdWalletReceptor, result.Value.Date,result.Value.Amount, result.Value.NameReceptingUser);

                return Created($"api/v1/transfer?id={result.Value?.Id}", resultTransfer);
            }
            return Problem(
            detail: result.Error,
            instance: HttpContext.Request.Path,
            statusCode: 400,
            title: result.Error,
            type: "https://httpstatuses.com/400"
            );
        }
    }
}
