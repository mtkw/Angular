using Microsoft.EntityFrameworkCore;
using MTKW_MyApi.DataAccess;

namespace MTKW_MyApi.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticlesByAuthorSurnameAsync(string author_surname)
        {
            var articles = await _context.ARCTICLES
                .Include(a => a.Author)
                .ToListAsync();

            return articles
                .Where(a => a.Author.SURNAME.ToLower() == author_surname.ToLower())
                .ToList();
        }

        public async Task<IEnumerable<Article>> GetArticlesByCategoryAsync(string category)
        {

            var articles = await _context.ARCTICLES
                .Include(a => a.Category)
                .ToListAsync();

            return articles
                .Where(a => a.Category.Name.ToLower() == category.ToLower())
                .ToList();
        }

        public void Update(Article article)
        {
            _context.Update(article);
        }
    }
}
