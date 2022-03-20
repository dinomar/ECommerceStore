using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class MockCatagoryRepository : ICategoryRepository
    {
        private List<Catagory> _categories = new List<Catagory>
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

        public IEnumerable<Catagory> Catagories => _categories;

        public void Save(Catagory catagory)
        {
            if (catagory.Id == 0)
            {
                catagory.Id = _categories.Last().Id + 1;
                _categories.Add(catagory);
            }
            else
            {
                Catagory temp = _categories.FirstOrDefault(c => c.Id == catagory.Id);
                if (temp != null)
                {
                    temp.Name = catagory.Name;
                }
            }
        }

        public bool Contains(string catagory)
        {
            foreach (Catagory item in _categories)
            {
                if (item.Name.ToLower() == catagory.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
