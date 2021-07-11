using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;
using Wpf_library.EntityFramework.Services;
using Wpf_library.EntityFramework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library.Validators
{
    public class MemberValidator:AbstractValidator<Member> 
    {
        public MemberValidator()
        {

            RuleFor(m => m.Name).SetValidator(new NameValidator());
            RuleFor(m => m.Email).SetValidator(new EmailValidator<Member>());
            RuleFor(m => m.Password).SetValidator(new PasswordValidator());
            RuleFor(m => m.PhoneNumber).SetValidator(new PhoneNumberValidator());
        }





    }
}
