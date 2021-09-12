using FluentValidation;
using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Validations.FluentValidations
{
    class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a user name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password");
        }
    }
}

