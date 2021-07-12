using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;

namespace Library.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {

            RuleFor(m => m.Name).SetValidator(new NameValidator());
            RuleFor(m => m.Email).SetValidator(new EmailValidator<Employee>());
            RuleFor(m => m.Password).SetValidator(new PasswordValidator());
            RuleFor(m => m.PhoneNumber).SetValidator(new PhoneNumberValidator());
        }





    }
}