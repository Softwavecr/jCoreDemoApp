using FluentValidation;

namespace jCoreDemoApp.Application.ContactItems.Queries.GetContactItemsWithPagination
{
    public class GetContactItemsWithPaginationQueryValidator : AbstractValidator<GetContactItemsWithPaginationQuery>
    {
        public GetContactItemsWithPaginationQueryValidator()
        {
            RuleFor(x => x.ListId)
                .NotNull()
                .NotEmpty().WithMessage("ListId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
