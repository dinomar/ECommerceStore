using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>()
        {
            new Order
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Smith",
                AddressLine1 = "My Address 1",
                AddressLine2 = "My Address 2",
                AddressLine3 = "My Address 3",
                City = "My City",
                State = "My State",
                ZipCode = "00001",
                Country = "My Country"
            }
        };

        public IEnumerable<Order> Orders => _orders;

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
