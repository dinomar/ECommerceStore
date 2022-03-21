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
        private readonly Cart _cart;

        public CartController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepo = productRepository;

            _cart = HttpContext.Session.GetJson<Cart>("cart");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            Product product = _productRepo.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cart.Add(product, 1);
                return Ok();
            }
            else
            {
                return BadRequest(new
                {
                    Error = "Product not found."
                });
            }
        }

        public IActionResult Add(int productId, string returnUrl)
        {
            Product product = _productRepo.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cart.Add(product, 1);
                // add to cast
            }

            // Redirect
            // return RedirectToAction("Index", "Home", new { returnUrl });
            return View();
        }

        public IActionResult Remove()
        {
            return View();
        }

        // @ViewContext.HttpContext.Request.PathAndQuery()
    }
}
