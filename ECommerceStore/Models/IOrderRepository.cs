using System.Collections.Generic;

namespace ECommerceStore.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void Save(Order order);
    }
}
