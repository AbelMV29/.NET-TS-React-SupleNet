using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.ItemCart.Commands.RemoveItemCart
{
    public class RemoveItemCartCommandHandler : IRequestHandler<RemoveItemCartCommand, Result<Unit>>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IItemCartRepository _itemCartRepository;

        public RemoveItemCartCommandHandler(IHttpContextAccessor httpContext, IItemCartRepository itemCartRepository)
        {
            _httpContext = httpContext;
            _itemCartRepository = itemCartRepository;
        }

        public async Task<Result<Unit>> Handle(RemoveItemCartCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                var existsItemInUserCart = await _itemCartRepository.GetByProductIdUser(request.ProductId, currentUserId);

                if (existsItemInUserCart is null)
                    return Result<Unit>.Failed("El producto especificado no existe en el carrito", HttpStatusCode.BadRequest);

                if(existsItemInUserCart.Quantity == 1)
                {
                    await _itemCartRepository.DeleteAsync(existsItemInUserCart);
                }
                else
                {
                    existsItemInUserCart.Quantity--;
                    await _itemCartRepository.UpdateAsync(existsItemInUserCart);   
                }
                await _itemCartRepository.SaveChangesAsync();
                return Result<Unit>.Success(Unit.Value, "Producto eliminado con exito", HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
