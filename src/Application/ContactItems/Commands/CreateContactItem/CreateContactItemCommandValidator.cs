using FluentValidation;

namespace jCoreDemoApp.Application.ContactItems.Commands.CreateContactItem
{
    public class CreateContactItemCommandValidator : AbstractValidator<CreateContactItemCommand>
    {
        public CreateContactItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
