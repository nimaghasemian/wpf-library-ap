using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Validators
{
    class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Password is required")
                .Must(BeValidPassword).WithMessage("Password must contain atleast one uppercase and should be between 8-32 charecters");
        }

        private bool BeValidPassword(string password)
        {
            Regex pass = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,32}$");
            Match confirm = pass.Match(password);
            return confirm.Success;
        }

    }
}
