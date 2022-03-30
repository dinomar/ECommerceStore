using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public EFOrderRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Order> Orders => _context.Orders;

        public void Save(Order order)
        {
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = _context.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (dbEntry != null)
                {
                    dbEntry.CartItems = order.CartItems;
                    dbEntry.Shipped = order.Shipped;
                    dbEntry.FirstName = order.FirstName;
                    dbEntry.LastName = order.LastName;
                    dbEntry.AddressLine1 = order.AddressLine1;
                    dbEntry.AddressLine2 = order.AddressLine2;
                    dbEntry.AddressLine3 = order.AddressLine3;
                    dbEntry.City = order.City;
                    dbEntry.State = order.State;
                    dbEntry.ZipCode = order.ZipCode;
                    dbEntry.Country = order.Country;
                }
            }

            _context.SaveChanges();
        }
    }
}
