using practica_controller_Service_Repository.Data;
using practica_controller_Service_Repository.Entities;
using practica_controller_Service_Repository.Repositories.Interfaces;

namespace practica_controller_Service_Repository.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        // Inyección de dependencias del DbContext
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> SearchProductsByName(string name)
        {
            return _context.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
    }
}