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
        Product UpdateProduct(Product product);
        bool Save();
        bool Delete(Product product);
        decimal? GetProductPrice(Guid id);
        bool ProductExist(Guid id);
    }
}
