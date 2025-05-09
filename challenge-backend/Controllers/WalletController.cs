using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL.Application.Services.Interfaces;

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
    }
}
