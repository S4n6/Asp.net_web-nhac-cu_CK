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

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public bool ExistCategory(Guid id)
        {
            return _context.Categories.Any(p => p.CategoryId == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(p => p.parentCategoryId).ToList();
        }

        public Category GetCategory(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public Category GetCategory(string categoryName)
        {
            return _context.Categories.Where(p => p.Name == categoryName).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
