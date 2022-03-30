using ECommerceStore.Models;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using RandomIdGeneratorLib;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceStore.Controllers
{
    //[Authorize(Roles = "Admins")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _env;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment environment)
        {
            _logger = logger;
            _productRepo = productRepository;
            _categoryRepo = categoryRepository;
            _env = environment;
        }

        public IActionResult Index()
        {
            return View(_productRepo.Products);
        }

        public IActionResult Create()
        {
            var list = _categoryRepo.Catagories.Select(c => new SelectListItem(c.Name, c.Name)).ToArray();
            ViewBag.Catagories = _categoryRepo.Catagories.Select(c => new SelectListItem(c.Name, c.Name));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    string ext = Path.GetExtension(model.Image.FileName);
                    string fileName = IdGenerator.Generate(10) + ext;
                    string path = Path.Combine(_env.WebRootPath, "images", fileName);

                    using (Stream stream = System.IO.File.Create(path))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    model.Product.Image = fileName;
                }

                Catagory foundCatagory = _categoryRepo.Catagories.FirstOrDefault(c => c.Name == model.Product.Name);
                if (foundCatagory == null)
                {
                    ModelState.AddModelError(string.Empty, "catagory doesn't exist.");
                    ViewBag.Catagories = _categoryRepo.Catagories.Select(c => new SelectListItem(c.Name, c.Name));
                    return View(model);
                }

                _productRepo.Save(model.Product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Catagories = _categoryRepo.Catagories.Select(c => new SelectListItem(c.Name, c.Name));
            return View(model);
        }
    }
}
