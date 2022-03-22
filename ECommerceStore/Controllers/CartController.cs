using ECommerceStore.Models;
using ECommerceStore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ECommerceStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;
        private Cart _cart;

        public CartController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepo = productRepository;
        }

        public IActionResult Index()
        {
            loadCart();
            return View(_cart.Items);
        }

        [HttpPost]
        public IActionResult Add(int id, string returnUrl, bool preventRedirect)
        {
            Product product = _productRepo.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                loadCart();
                _cart.Add(product, 1);
                saveCart();
                if (preventRedirect)
                {
                    return Ok();
                }
                else
                {
                    return Redirect(returnUrl);
                }
                
            }
            else
            {
                if (preventRedirect)
                {
                    return BadRequest(new
                    {
                        Error = "Product not found."
                    });
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
        }

        public IActionResult Remove([FromRoute] int id)
        {
            Product product = _productRepo.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                loadCart();
                _cart.Remove(product);
                saveCart();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            loadCart();
            _cart.Clear();
            saveCart();
            return RedirectToAction(nameof(Index));
        }

        private void loadCart()
        {
            _cart = HttpContext.Session.GetJson<Cart>("cart");
            if (_cart == null)
            {
                _cart = new Cart();
            }
        }

        private void saveCart()
        {
            HttpContext.Session.SetJson("cart", _cart);
        }
    }
}
