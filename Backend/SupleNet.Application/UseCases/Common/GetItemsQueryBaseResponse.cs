namespace SupleNet.Application.UseCases.Common
{
    public abstract record GetItemsQueryBaseResponse (Guid Id, string Name, DateTime CreatedDate);
}
