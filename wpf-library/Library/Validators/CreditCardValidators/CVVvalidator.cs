using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Validators.CreditCardValidators
{
    class CVVvalidator:AbstractValidator<string>
    {
        public CVVvalidator()
        {
            RuleFor(cvvNum => cvvNum).Matches(new Regex(@"\d{3,4}")).WithMessage("That CVV2 is not valid");
        }
    }
}
