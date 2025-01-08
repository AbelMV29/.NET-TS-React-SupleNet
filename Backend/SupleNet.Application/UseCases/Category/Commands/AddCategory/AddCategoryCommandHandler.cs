using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.Category.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Result<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContext;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IHttpContextAccessor httpContext)
        {
            _categoryRepository = categoryRepository;
            _httpContext = httpContext;
        }

        public async Task<Result<Unit>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (await _categoryRepository.ExistByName(request.Name))
                return Result<Unit>.Failed($"La categoría con el nombre {request.Name} ya existe", HttpStatusCode.BadRequest);

            var categoryToAdd = new Domain.Entities.Category
            {
                Name = request.Name,
                CreatedBy = currentUserId,
                CreatedDate = DateTime.UtcNow.AddHours(-3),
            };

            try
            {
                await _categoryRepository.AddAsync(categoryToAdd);
                await _categoryRepository.SaveChangesAsync();
                return Result<Unit>.Success(Unit.Value, $"Categoría {request.Name} creada con éxito", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
