using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Catagory> Catagories { get; }
        void Save(Catagory catagory);
        bool Contains(string catagory);
    }
}
