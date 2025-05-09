using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Application.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
