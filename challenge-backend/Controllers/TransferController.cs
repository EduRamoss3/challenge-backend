using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL.Application.Services.Interfaces;

namespace challenge_backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

    }
}
