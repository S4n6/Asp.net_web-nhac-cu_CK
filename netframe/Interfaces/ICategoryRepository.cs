using netframe.Models;

namespace netframe.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(Guid id);
        Category GetCategory(string categoryName);
    }
}
