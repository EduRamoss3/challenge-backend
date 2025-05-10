using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.DTO;

namespace WL.Application.Validation
{
    public class TransferDTOValidation : AbstractValidator<TransferDTO>
    {
        public TransferDTOValidation()
        {
            RuleFor(x => x.amount).GreaterThan(0.1m).WithMessage("The number can't be less or equal 0");
        }
    }
}
