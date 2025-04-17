
namespace MTKW_MyApi.Data.Repository
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }

        void Save();
        Task SaveAsync();
    }
}
