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
            RuleFor(password => password).Cascade(CascadeMode.Stop).NotNull().WithMessage("{PropertyName} is required")
                .Must(BeValidPassword).WithMessage("Must contain one uppercase and should be between 8-32 charecter");
        }

        private bool BeValidPassword(string password)
        {
            Regex pass = new Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$");
            Match confirm = pass.Match(password);
            return confirm.Success;
        }

    }
}
