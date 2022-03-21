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
        private readonly ICategoryRepository _categoryRepo;
        private readonly int _productsPerPage = 6;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepo = productRepository;
            _categoryRepo = categoryRepository;
        }

        public IActionResult Index([FromQuery]string catagory = "", [FromQuery]int page = 1)
        {
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Catagories = _categoryRepo.Catagories.Select(c => c.Name),
                CurrentPage = page
            };

            if (!string.IsNullOrEmpty(catagory) && _categoryRepo.Contains(catagory))
            {
                viewModel.CurrentCatagory = catagory;
                viewModel.Products = _productRepo.Products
                    .Where(p => p.Catagory == catagory)
                    .Skip((page - 1) * _productsPerPage)
                    .Take(_productsPerPage);
            }
            else
            {
                viewModel.Products = _productRepo.Products
                    .Skip((page - 1) * _productsPerPage)
                    .Take(_productsPerPage);
            }

            return View(viewModel);
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
