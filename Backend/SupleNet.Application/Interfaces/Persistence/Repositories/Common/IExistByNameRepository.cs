namespace SupleNet.Application.Interfaces.Persistence.Repositories.Common
{
    public interface IExistByNameRepository<T> where T:class
    {
        Task<bool> ExistByName(string name);
    }
}
