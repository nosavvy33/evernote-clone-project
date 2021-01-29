using Evernote.Domain.ValueObjects;
using FluentValidation;

namespace Evernote.Application.Validations
{
    public class NoteValidator : AbstractValidator<NoteDTO>
    {
        public NoteValidator() 
        {
            RuleFor(c => c.Content).NotEmpty().WithMessage("Empty Contentaaaaa");
        }
    }
}
