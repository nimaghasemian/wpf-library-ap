using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Validators.CreditCardValidators
{
    class expDateValidator: AbstractValidator<DateTime>
    {
        public expDateValidator()
        {
            RuleFor(date => date).Must(BeValidDate).WithMessage("Card Expired");
        }

        private bool BeValidDate(DateTime expdate)
        {
            int days = (expdate - DateTime.Now).Days;
            return days > 90;

        }
    }
}
