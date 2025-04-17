namespace MTKW_MyApi.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByNameAsync(string name);
    }
}
