using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
