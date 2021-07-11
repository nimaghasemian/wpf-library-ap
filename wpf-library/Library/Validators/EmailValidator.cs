using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;

namespace Library.Validators
{
    class EmailValidator<T>:AbstractValidator<string> where T: BasePerson
    {
        public EmailValidator()
        {
            RuleFor(email => email).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid")
                .MustAsync(async (email, cancellation) => {
                    UserDataService<T> memberService = new UserDataService<T>(new WpfLibraryDbContextFactory());
                    var user = await memberService.GetByEmail(email);
                    if (user != null)
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("That email is already registered");
        }
    }
}
