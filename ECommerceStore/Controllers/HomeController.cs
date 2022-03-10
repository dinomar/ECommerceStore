using ECommerceStore.Models;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepo = productRepository;
        }

        public IActionResult Index()
        {
            return View(new ProductListViewModel
            {
                Products = _productRepo.Products
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
