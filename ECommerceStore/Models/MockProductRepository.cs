using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class MockProductRepository : IProductRepository
    {
        private static List<Catagory> _catagories = new List<Catagory>
        {
            new Catagory
            {
                Id = 1,
                Name = "Electronics"
            },
            new Catagory
            {
                Id = 2,
                Name = "Outdoor"
            },
            new Catagory
            {
                Id = 3,
                Name = "Office"
            }
        };

        private List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Dell 24\" Monitor | Black",
                Description = "Dell 24\" Monitor | Black",
                Price = 3199M,
                Catagory = _catagories[0].Name // Electronics
            },
            new Product
            {
                Id = 2,
                Name = "HP Notebook 255 G8",
                Description = "HP Notebook 255 G8",
                Price = 8999M,
                Catagory = _catagories[0].Name // Electronics
            },
            new Product
            {
                Id = 3,
                Name = "Canon SX540 Digital Camera Black",
                Description = "Canon SX540 Digital Camera Black",
                Price = 12999M,
                Catagory = _catagories[0].Name // Electronics
            },
            new Product
            {
                Id = 4,
                Name = "Canon SX0 Digital Camera",
                Description = "Canon SX0 Digital Camera",
                Price = 2999M,
                Catagory = _catagories[0].Name // Electronics
            },

            new Product
            {
                Id = 5,
                Name = "Oztrail Tasman Dome Tent",
                Description = "Oztrail Tasman Dome Tent",
                Price = 849M,
                Catagory = _catagories[1].Name // Outdoor
            },
            new Product
            {
                Id = 6,
                Name = "Outdoor Wood Burning Camping Stove & Grill",
                Description = "Outdoor Wood Burning Camping Stove & Grill",
                Price = 699M,
                Catagory = _catagories[1].Name // Outdoor
            },
            new Product
            {
                Id = 7,
                Name = "Eiger Vacuum Flask - 700ml",
                Description = "Eiger Vacuum Flask - 700ml",
                Price = 279M,
                Catagory = _catagories[1].Name // Outdoor
            },

            new Product
            {
                Id = 8,
                Name = "Canon Pixma TS5340 Printer",
                Description = "Canon Pixma TS5340 Printer",
                Price = 1298M,
                Catagory = _catagories[2].Name // Office
            },
            new Product
            {
                Id = 9,
                Name = "Typek Box A4 White Copier Paper",
                Description = "Typek Box A4 White Copier Paper",
                Price = 369M,
                Catagory = _catagories[2].Name // Office
            },
            new Product
            {
                Id = 10,
                Name = "Parrot A4 Clipboard",
                Description = "Parrot A4 Clipboard",
                Price = 29M,
                Catagory = _catagories[2].Name // Office
            }
        };

        public IEnumerable<Product> Products => _products;

        public void Save(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = _products.Last().Id + 1;
                _products.Add(product);
            }
            else
            {
                Product temp = _products.FirstOrDefault(p => p.Id == product.Id);
                if (temp != null)
                {
                    temp.Name = product.Name;
                    temp.Description = product.Description;
                    temp.Price = product.Price;
                }
            }
        }
    }
}
