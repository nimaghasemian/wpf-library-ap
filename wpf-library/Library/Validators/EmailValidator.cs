using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;

namespace Library.Validators
{
    class EmailValidator:AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email).Cascade(CascadeMode.Stop).NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is invalid")
                .MustAsync(async (email, cancellation) => {
                    UserDataService<BasePerson> memberService = new UserDataService<BasePerson>(new WpfLibraryDbContextFactory());
                    var user = await memberService.GetByEmail(email);
                    if (user.Equals(null))
                    {
                        return true;
                    }
                    return false;
                }).WithMessage("That email is already registered");
        }
    }
}
