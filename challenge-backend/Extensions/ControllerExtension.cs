using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace challenge_backend.Extensions
{
    public static class ControllerExtensions
    {
        public static Guid? GetAuthenticatedUserId(this ControllerBase controller)
        {
            var userIdClaim = controller.User.FindFirst(ClaimTypes.Sid)?.Value;
            return Guid.TryParse(userIdClaim, out var userId) ? userId : (Guid?)null;
        }
    }
}
