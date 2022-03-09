using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Catagory> _catagories = new List<Catagory>
        {
            new Catagory
            {
                Id = 0,
                Name = "Electronics"
            },
            new Catagory
            {
                Id = 1,
                Name = "Outdoor"
            },
            new Catagory
            {
                Id = 2,
                Name = "Office"
            }
        };

        public IEnumerable<Product> Products => new List<Product>()
        {
            new Product
            {
                Id = 0,
                Name = "Dell 24\" Monitor | Black",
                Description = "Dell 24\" Monitor | Black",
                Price = 3199M,
                Catagory = _catagories[0] // Electronics
            },
            new Product
            {
                Id = 1,
                Name = "HP Notebook 255 G8",
                Description = "HP Notebook 255 G8",
                Price = 8999M,
                Catagory = _catagories[0] // Electronics
            },
            new Product
            {
                Id = 2,
                Name = "Canon SX540 Digital Camera Black",
                Description = "Canon SX540 Digital Camera Black",
                Price = 12999M,
                Catagory = _catagories[0] // Electronics
            },

            new Product
            {
                Id = 3,
                Name = "Oztrail Tasman Dome Tent",
                Description = "Oztrail Tasman Dome Tent",
                Price = 849M,
                Catagory = _catagories[1] // Outdoor
            },
            new Product
            {
                Id = 4,
                Name = "Outdoor Wood Burning Camping Stove & Grill",
                Description = "Outdoor Wood Burning Camping Stove & Grill",
                Price = 699M,
                Catagory = _catagories[1] // Outdoor
            },
            new Product
            {
                Id = 5,
                Name = "Eiger Vacuum Flask - 700ml",
                Description = "Eiger Vacuum Flask - 700ml",
                Price = 279M,
                Catagory = _catagories[1] // Outdoor
            },

            new Product
            {
                Id = 6,
                Name = "Canon Pixma TS5340 Printer",
                Description = "Canon Pixma TS5340 Printer",
                Price = 1298M,
                Catagory = _catagories[2] // Office
            },
            new Product
            {
                Id = 7,
                Name = "Typek Box A4 White Copier Paper",
                Description = "Typek Box A4 White Copier Paper",
                Price = 369M,
                Catagory = _catagories[2] // Office
            },
            new Product
            {
                Id = 8,
                Name = "Parrot A4 Clipboard",
                Description = "Parrot A4 Clipboard",
                Price = 29M,
                Catagory = _catagories[2] // Office
            }
        };
    }
}
