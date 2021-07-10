using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;

namespace Library.Validators
{
    class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).SetValidator(new NameValidator());
            RuleFor(book => book.Author).SetValidator(new NameValidator());
            RuleFor(book => book.Genre).SetValidator(new NameValidator());
            RuleFor(book => book.ISBN).NotNull().WithMessage("ISBN is required")
               .GreaterThan(999999999).WithMessage("enter a valid ISBN");//10 digit
        }
    }
}
