using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public static class AppSeedData
    {
        private static List<Catagory> _catagories = new List<Catagory>
        {
            new Catagory
            {
                Name = "Electronics"
            },
            new Catagory
            {
                Name = "Outdoor"
            },
            new Catagory
            {
                Name = "Office"
            }
        };

        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Name = "Dell 24\" Monitor | Black",
                Description = "Dell 24\" Monitor | Black",
                Price = 3199M,
                Catagory = _catagories[0].Name, // Electronics
                Image = "Dell-24-Monitor-Black.jpg"
            },
            new Product
            {
                Name = "HP Notebook 255 G8",
                Description = "HP Notebook 255 G8",
                Price = 8999M,
                Catagory = _catagories[0].Name, // Electronics
                Image = "HP-Notebook-255-G8.jpg"
            },
            new Product
            {
                Name = "Canon SX540 Digital Camera Black",
                Description = "Canon SX540 Digital Camera Black",
                Price = 12999M,
                Catagory = _catagories[0].Name, // Electronics
                Image = "Canon-SX540-Digital-Camera-Black.jpg"
            },
            new Product
            {
                Name = "Canon SX0 Digital Camera",
                Description = "Canon SX0 Digital Camera",
                Price = 2999M,
                Catagory = _catagories[0].Name, // Electronics
                Image = "Canon-SX0-Digital-Camera.jpg"
            },

            new Product
            {
                Name = "Oztrail Tasman Dome Tent",
                Description = "Oztrail Tasman Dome Tent",
                Price = 849M,
                Catagory = _catagories[1].Name, // Outdoor
                Image = "Oztrail-Tasman-Dome-Tent.jpg"
            },
            new Product
            {
                Name = "Outdoor Wood Burning Camping Stove & Grill",
                Description = "Outdoor Wood Burning Camping Stove & Grill",
                Price = 699M,
                Catagory = _catagories[1].Name, // Outdoor
                Image = "Outdoor-Wood-Burning-Camping-Stove.jpg"
            },
            new Product
            {
                Name = "Eiger Vacuum Flask - 700ml",
                Description = "Eiger Vacuum Flask - 700ml",
                Price = 279M,
                Catagory = _catagories[1].Name, // Outdoor
                Image = "Eiger-Vacuum-Flask.jpg"
            },

            new Product
            {
                Name = "Canon Pixma TS5340 Printer",
                Description = "Canon Pixma TS5340 Printer",
                Price = 1298M,
                Catagory = _catagories[2].Name, // Office
                Image = "Canon-Pixma-TS5340-Printer.jpg"
            },
            new Product
            {
                Name = "Typek Box A4 White Copier Paper",
                Description = "Typek Box A4 White Copier Paper",
                Price = 369M,
                Catagory = _catagories[2].Name, // Office
                Image = "Typek-Box-A4-White-Copier-Paper.jpg"
            },
            new Product
            {
                Name = "Parrot A4 Clipboard",
                Description = "Parrot A4 Clipboard",
                Price = 29M,
                Catagory = _catagories[2].Name, // Office
                Image = "Parrot-A4-Clipboard.jpg"
            }
        };

        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            AppDbContext context = serviceProvider.GetRequiredService<AppDbContext>();

            foreach (Catagory catagory in _catagories)
            {
                if (context.Catagories.FirstOrDefault(c => c.Name == catagory.Name) == null)
                {
                    context.Catagories.Add(catagory);
                }
            }

            foreach (Product product in _products)
            {
                if (context.Products.FirstOrDefault(p => p.Name == product.Name) == null)
                {
                    context.Products.Add(product);
                }
            }

            context.SaveChanges();
        }
    }
}
