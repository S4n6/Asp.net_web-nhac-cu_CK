using netframe.Data;
using netframe.Interfaces;
using netframe.Models;

namespace netframe.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(p => p.parentCategoryId).ToList();
        }

        public Category GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
