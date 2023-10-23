using netframe.Models;


namespace netframe.Data.Seeding
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context) { _context = context; }
        public void SeedDataContext()
        {
            // Check if any data already exists
            if (_context.Categories.Any() || _context.Products.Any())
            {
                return; // Data has already been seeded
            }

            // Create sample categories
            var categories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), Name = "Guitar" },
                new Category { CategoryId = Guid.NewGuid(), Name = "Piano" },
                new Category { CategoryId = Guid.NewGuid(), Name = "Drum" },
                new Category { CategoryId = Guid.NewGuid(), Name = "Strings" },
                new Category { CategoryId = Guid.NewGuid(),Name="Other Accessories"}
            };

            // Find the ID of the "Guitar" category
            var guitarCategoryId = categories.FirstOrDefault(c => c.Name == "Guitar")?.CategoryId;
            var pianoCategoryId = categories.FirstOrDefault(c => c.Name == "Piano")?.CategoryId;
            var drumCategoryId = categories.FirstOrDefault(c => c.Name == "Drum")?.CategoryId;
            var stringsCategoryId = categories.FirstOrDefault(c => c.Name == "Strings")?.CategoryId;
            var accessoriesCategoryId = categories.FirstOrDefault(c => c.Name == "Other Accessories")?.CategoryId;



            var miniCategories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), Name = "Electric Guitar", parentCategoryId = guitarCategoryId },
                new Category { CategoryId = Guid.NewGuid(), Name = "Classical Guitar", parentCategoryId = guitarCategoryId },
                new Category { CategoryId = Guid.NewGuid(), Name = "Ukulele", parentCategoryId = guitarCategoryId },

                new Category { CategoryId = Guid.NewGuid(), Name = "Grand Piano", parentCategoryId = pianoCategoryId },
                new Category { CategoryId = Guid.NewGuid(), Name = "E-Piano", parentCategoryId = pianoCategoryId },

                new Category { CategoryId = Guid.NewGuid(), Name = "E-Drum", parentCategoryId = drumCategoryId },
                new Category { CategoryId = Guid.NewGuid(),Name = "Acoustic Drum", parentCategoryId = drumCategoryId},

                new Category { CategoryId = Guid.NewGuid(),Name = "Violins", parentCategoryId = stringsCategoryId},
                new Category { CategoryId = Guid.NewGuid(),Name = "Cellos", parentCategoryId = stringsCategoryId},

                new Category { CategoryId = Guid.NewGuid(),Name = "Accessories For Guitar", parentCategoryId = accessoriesCategoryId},
                new Category { CategoryId = Guid.NewGuid(),Name = "Accessories For Piano", parentCategoryId = accessoriesCategoryId},
                new Category { CategoryId = Guid.NewGuid(),Name = "Accessories For Drum", parentCategoryId = accessoriesCategoryId},
                new Category { CategoryId = Guid.NewGuid(),Name = "Accessories For Strings", parentCategoryId = accessoriesCategoryId},

            };

            _context.Categories.AddRange(categories);
            _context.Categories.AddRange(miniCategories);
            _context.SaveChanges();

            // Create sample products
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 5,
                    Price = 10m,
                    Quantity = 20,
                    CategoryId = miniCategories[0].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 4,
                    Price = 15m,
                    Quantity = 10,
                    CategoryId = miniCategories[1].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 3",
                    Description = "Description for Product 3",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 3,
                    Price = 20m,
                    Quantity = 5,
                    CategoryId = miniCategories[2].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 4",
                    Description = "Description for Product 4",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 3,
                    Price = 12.3m,
                    Quantity = 5,
                    CategoryId = miniCategories[2].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 5",
                    Description = "Description for Product 5",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 3,
                    Price = 20m,
                    Quantity = 5,
                    CategoryId = miniCategories[3].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 6",
                    Description = "Description for Product 6",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 3,
                    Price = 20.7m,
                    Quantity = 5,
                    CategoryId = miniCategories[3].CategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Product 7",
                    Description = "Description for Product 7",
                    ImageLink = "https://placehold.co/600x400",
                    Quality = 3,
                    Price = 20.7m,
                    Quantity = 5,
                    CategoryId = miniCategories[4].CategoryId
                },
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}