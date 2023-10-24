using netframe.Models;

namespace netframe.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(Guid id);
        Category GetCategory(string categoryName);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool Save();
        bool DeleteCategory(Category category);
        bool ExistCategory(Guid id);

    }
}
