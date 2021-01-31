using FluentValidation;

namespace jCoreDemoApp.Application.ContactItems.Commands.UpdateContactItem
{
    public class UpdateContactItemCommandValidator : AbstractValidator<UpdateContactItemCommand>
    {
        public UpdateContactItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
