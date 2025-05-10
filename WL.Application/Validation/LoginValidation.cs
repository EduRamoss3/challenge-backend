using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Application.Model;

namespace WL.Application.Validation
{
    public class LoginValidation : AbstractValidator<LoginModel>
    {
        public LoginValidation()
        {
      
            RuleFor(p => p.Email)
                 .NotEmpty().WithMessage("Email is required!")
                .MinimumLength(20).WithMessage("Email require minimum twenty characters")
                .MaximumLength(200).WithMessage("Email too long")
                .NotNull().WithMessage("Email cannot be null")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email is not in correct format, check if has a @ sign");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(10).WithMessage("Password require minimum ten characters")
                .MaximumLength(200).WithMessage("Password too long");
        }
    }
}
