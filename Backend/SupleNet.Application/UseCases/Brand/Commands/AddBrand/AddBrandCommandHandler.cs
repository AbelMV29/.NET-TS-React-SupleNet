using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.Brand.Commands.AddBrand
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, Result<Unit>>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBrandRepository _brandRepository;

        public AddBrandCommandHandler(IHttpContextAccessor httpContext, IBrandRepository brandRepository)
        {
            _httpContext = httpContext;
            _brandRepository = brandRepository;
        }

        public async Task<Result<Unit>> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                await _brandRepository.AddAsync(new Domain.Entities.Brand
                {
                    Name = request.Name,
                    CreatedBy = currentUserId,
                    CreatedDate = DateTime.UtcNow.AddHours(-3),
                });

                await _brandRepository.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value, $"La marca {request.Name} ha sido agregada exitosamente", HttpStatusCode.Created);
            }
            catch(Exception ex) 
            {
                return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }

        }
    }
}
