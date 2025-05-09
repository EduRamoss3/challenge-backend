using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Domain.Entities;

namespace WL.Application.DTO
{
    public record NormalUserDTO(string Name, string Email, string Password)
    {
        public static implicit operator User(NormalUserDTO request)
        {
            return new User(request.Name, request.Email, request.Password);
           
        }
    }
}
