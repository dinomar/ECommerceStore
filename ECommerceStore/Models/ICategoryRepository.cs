using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public interface ICategoryRepository
    {
        public IEnumerable<Catagory> Catagories { get; }
    }
}
