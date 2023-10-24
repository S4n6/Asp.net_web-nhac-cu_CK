using netframe.Models;

namespace netframe.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        ICollection<Product> GetProductsByCategory(Guid categoryId);

        Product GetProduct(Guid id);
        Product GetProduct(string productName);

        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool Save();
        bool DeleteProduct(Product product);
        decimal? GetProductPrice(Guid id);
        bool ExistProduct(Guid id);
    }
}
