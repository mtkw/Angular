namespace MTKW_MyApi.Data.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<Article>> GetArticlesByCategoryAsync(string category);
        Task<IEnumerable<Article>> GetArticlesByAuthorSurnameAsync(string author_surname);
        void Update(Article article);
    }
}
