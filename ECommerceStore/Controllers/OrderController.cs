using ECommerceStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ECommerceStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderRepository _orderRepo;
        private readonly Cart _cart;

        public OrderController(ILogger<HomeController> logger, IOrderRepository orderRepository, Cart cart)
        {
            _logger = logger;
            _orderRepo = orderRepository;
            _cart = cart;
        }

        //[Authorize]
        public IActionResult Index() => View(_orderRepo.Orders.OrderByDescending(o => o.Id));

        //[Authorize]
        public IActionResult Details([FromRoute]int id)
        {
            Order order = _orderRepo.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                return View(order);
            }

            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult MarkShipped([FromForm]int id)
        {
            Order order = _orderRepo.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.Shipped = true;
                _orderRepo.Save(order);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Checkout() => View();

        [HttpPost]
        public IActionResult Checkout(Order model)
        {
            if (_cart.Items.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "There are no items in your cart!");
            }

            if (ModelState.IsValid)
            {
                model.CartItems = _cart.Items.ToArray();
                _orderRepo.Save(model);
                _cart.Clear();
                return RedirectToAction("Index", "Payment");
            }
            else
            {
                return View(model);
            }
        }
    }
}
