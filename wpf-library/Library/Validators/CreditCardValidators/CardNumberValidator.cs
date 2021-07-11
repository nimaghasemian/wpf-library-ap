using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Validators.CreditCardValidators
{
    class CardNumberValidator : AbstractValidator<string>
    {
        public CardNumberValidator()
        {
            RuleFor(cardNumber => cardNumber).Must(BeValidCard).WithMessage("That card number is not valid");
        }

        private bool BeValidCard(string cardNumber)
        {
            List<char> chars = cardNumber.ToList();
            IEnumerable<int> intofChars = chars.Select(c => int.Parse($"{c}"));
            int finalNumber = intofChars.Select((a, index) => index % 2 == 0 ? a * 2 : a)
                .Select((a, index) => index % 2 != 0 ? a : a >= 10 ? a % 10 + a / 10 : a)
                .Aggregate(0, (acc, a) => a + acc);
            return finalNumber % 10 == 0;
        }
    }
}
