using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        public IEnumerable<Order> Orders => throw new System.NotImplementedException();

        public void Save(Order order)
        {
            if (order.Id == 0)
            {
                int nextId = _orders.Select(o => o.Id).Max() + 1;
                order.Id = nextId;
                _orders.Add(order);
            }
            else
            {
                int index = _orders.FindIndex(o => o.Id == order.Id);
                if (index > 0)
                {
                    _orders[index] = order;
                }
            }
        }
    }
}
