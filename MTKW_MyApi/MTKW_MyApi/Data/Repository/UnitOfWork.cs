using MTKW_MyApi.DataAccess;

namespace MTKW_MyApi.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context { get; private set; }

        public IArticleRepository Articles { get; private set; }
        public ICategoryRepository Categories { get; private set; }


        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
