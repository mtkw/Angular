using System.Linq.Expressions;

namespace MTKW_MyApi.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includProperties = null);
        void Add(T entity);
        void AddAsync(T entity);

        public Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includProperties = null);

        void Remove(T entity);

        Task<T> Get(Expression<Func<T, bool>>? filter = null, string? includProperties = null);

    }
}
