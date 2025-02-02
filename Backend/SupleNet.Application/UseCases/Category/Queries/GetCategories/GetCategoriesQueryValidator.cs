using FluentValidation;

namespace SupleNet.Application.UseCases.Category.Queries.GetCategories
{
    public class GetCategoriesQueryValidator : AbstractValidator<GetCategoriesQuery>
    {
        public GetCategoriesQueryValidator()
        {
            RuleFor(x => x.OrderByDate)
                .NotNull().WithMessage("El Orden por fecha es obligatorio");
        }
    }
}
