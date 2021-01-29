using FluentValidation;

namespace Evernote.Application.Validations
{
    //This Validator and POCO is only for test purposes
    public class WhateverValidator : AbstractValidator<Whatever>
    {
        public WhateverValidator() 
        {
            RuleFor(c => c.Message).NotEmpty().WithMessage("Content must not be empty");
        }
    }

    public class Whatever {
        public string Message { get; set; }
    }
}
