using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.DTO;

namespace WL.Application.Validation
{
    public class WalletDTOValidation : AbstractValidator<WalletDTO>
    {
        public WalletDTOValidation()
        {
            RuleFor(p => p.amount)
                .GreaterThan(0)
                .WithMessage("The value must be greater than 0");

            RuleFor(p => p.uid)
                .NotNull()
                .WithMessage("User id can't be null");
        }
    }
}
