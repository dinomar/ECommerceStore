using ECommerceStore.Models;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using RandomIdGeneratorLib;

namespace ECommerceStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repo;
        private readonly IWebHostEnvironment _env;

        public ProductController(ILogger<ProductController> logger, IProductRepository repository, IWebHostEnvironment environment)
        {
            _logger = logger;
            _repo = repository;
            _env = environment;
        }

        public IActionResult Index()
        {
            return View(_repo.Products);
        }

        public IActionResult Create()
        {
            // bootstrap fix
            // return catagory select list
            return View();
        }

        [HttpPost]
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

                // if catagory exists, else return err.

                _repo.Save(model.Product);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
