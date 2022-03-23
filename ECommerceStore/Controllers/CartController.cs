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

        public CartController(ILogger<HomeController> logger, IProductRepository productRepository, Cart cart)
        {
            _logger = logger;
            _productRepo = productRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View(_cart.Items);
        }

        [HttpPost]
        public IActionResult Add(int id, string returnUrl, bool preventRedirect)
        {
            Product product = _productRepo.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _cart.Add(product, 1);
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
                _cart.Remove(product);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _cart.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
