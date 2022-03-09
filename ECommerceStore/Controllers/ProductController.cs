using ECommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repo;

        public ProductController(ILogger<ProductController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repo = repository;
        }

        public IActionResult Index()
        {
            return View(_repo.Products);
        }
    }
}
