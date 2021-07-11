using FluentValidation;
using System.Text.RegularExpressions;
using Wpf_library.Domain.Models;

namespace Library.Validators
{
    public class PhoneNumberValidator : AbstractValidator<string>
    {
        public PhoneNumberValidator()
        {
            RuleFor(phoneNumber => phoneNumber).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Phone number is required")
                .Must(BeValidPhoneNumber).WithMessage("Enter a valid phone number");
        }
        private bool BeValidPhoneNumber(string phonenumber)
        {
            Regex phone = new Regex(@"^09\d{9}");
            Match confirm = phone.Match(phonenumber);
            return confirm.Success;
        }
    }
}