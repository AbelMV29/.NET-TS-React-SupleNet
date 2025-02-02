using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.ItemCart.Commands.RemoveFullItemCart
{
    public class RemoveFullItemCartCommandHandler : IRequestHandler<RemoveFullItemCartCommand, Result<Unit>>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IItemCartRepository _itemCartRepository;

        public RemoveFullItemCartCommandHandler(IHttpContextAccessor contextAccessor, IItemCartRepository itemCartRepository)
        {
            _contextAccessor = contextAccessor;
            _itemCartRepository = itemCartRepository;
        }

        public async Task<Result<Unit>> Handle(RemoveFullItemCartCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                var existsItemInUserCart = await _itemCartRepository.GetByProductIdUser(request.ProductId, currentUserId);

                if (existsItemInUserCart is null)
                    return Result<Unit>.Failed("El producto especificado no existe en el carrito", HttpStatusCode.BadRequest);

                await _itemCartRepository.DeleteAsync(existsItemInUserCart);
                await _itemCartRepository.SaveChangesAsync();
                return Result<Unit>.Success(Unit.Value, "Producto eliminado con exito", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
