using System.Collections.Generic;
using System.Linq;

namespace BDSA2015.Lecture03
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository()
        {
            _context = new ShopContext();
        }

        public int Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public void Delete(int productId)
        {
            var entity = _context.Products.Find(productId);

            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Product> Read()
        {
            return _context.Products.ToList();
        }

        public Product Read(int productId)
        {
            var product = _context.Products.Find(productId);

            return product;
        }

        public void Update(Product product)
        {
            var entity = _context.Products.Find(product.Id);

            entity.Name = product.Name;
            entity.Price = product.Price;

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
