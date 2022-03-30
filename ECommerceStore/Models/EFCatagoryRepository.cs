using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class EFCatagoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public EFCatagoryRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Catagory> Catagories => _context.Catagories;

        public bool Contains(string catagory)
        {
            return _context.Catagories.Any(c => c.Name.ToLower() == catagory.ToLower());
        }

        public void Save(Catagory catagory)
        {
            if (catagory.Id == 0)
            {
                _context.Catagories.Add(catagory);
            }
            else
            {
                Catagory dbEntry = _context.Catagories.FirstOrDefault(c => c.Id == catagory.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = catagory.Name;
                }
            }

            _context.SaveChanges();
        }
    }
}
