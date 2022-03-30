using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public EFProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Product> Products => _context.Products;

        public void Save(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Catagory = product.Catagory;
                    dbEntry.Image = product.Image;
                }
            }

            _context.SaveChanges();
        }
    }
}
