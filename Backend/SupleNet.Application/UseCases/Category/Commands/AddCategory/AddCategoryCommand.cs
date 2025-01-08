using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Category.Commands.AddCategory
{
    public record AddCategoryCommand(string Name) : IRequest<Result<Unit>>;
}
