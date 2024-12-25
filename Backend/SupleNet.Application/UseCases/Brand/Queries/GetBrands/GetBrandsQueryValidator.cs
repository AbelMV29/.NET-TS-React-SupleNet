using FluentValidation;

namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    public class GetBrandsQueryValidator : AbstractValidator<GetBrandsQuery>
    {
        public GetBrandsQueryValidator()
        {
            RuleFor(x => x.OrderByDate)
                .NotEmpty().WithMessage("El Orden por fecha es obligatorio");
        }
    }
}
