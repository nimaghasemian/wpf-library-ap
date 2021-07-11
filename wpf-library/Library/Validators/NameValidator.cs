using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Validators
{
    class NameValidator:AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(name => name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is required")
               .Length(4, 50).WithMessage("Name Length should be of length 4 to 50")
               .Must(beValidName).WithMessage("Name contains invalid characters");
        }

        private bool beValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
