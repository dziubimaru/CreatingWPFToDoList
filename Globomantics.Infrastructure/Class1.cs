namespace Globomantics.Infrastructure
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Guid id);
    }
}