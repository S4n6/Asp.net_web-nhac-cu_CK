using Microsoft.EntityFrameworkCore;
using netframe.Data;
using netframe.Interfaces;
using netframe.Models;

namespace netframe.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            //Change Tracker
            //add, update, modifying
            //connected vs disconnected
            _context.Add(product);

            return Save();
        }

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.Find(id);
        }

        public Product GetProduct(string productName)
        {
            return _context.Products.Where(p => p.Name == productName).FirstOrDefault();
        }

        public decimal? GetProductPrice(Guid id)
        {
            var product = _context.Set<Product>().Find(id);
            return product?.Price ?? 0;
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p=>p.ProductId).ToList();
        }

        public ICollection<Product> GetProductsByCategory(Guid categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool ProductExist(Guid id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
