namespace SupleNet.Application.UseCases.Common
{
    public abstract record GetItemsQueryBase (string Name = "", bool OrderByDate = false);
}
