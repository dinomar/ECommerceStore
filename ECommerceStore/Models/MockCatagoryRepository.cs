using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public class MockCatagoryRepository : ICategoryRepository
    {
        public IEnumerable<Catagory> Catagories => new List<Catagory>
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
    }
}
