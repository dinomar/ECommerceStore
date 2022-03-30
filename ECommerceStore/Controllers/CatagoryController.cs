using ECommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Controllers
{
    //[Authorize(Roles = "Admins")]
    public class CatagoryController : Controller
    {
        private readonly ILogger<CatagoryController> _logger;
        private readonly ICategoryRepository _repo;

        public CatagoryController(ILogger<CatagoryController> logger, ICategoryRepository repository)
        {
            _logger = logger;
            _repo = repository;
        }

        public IActionResult Index()
        {
            return View(_repo.Catagories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(catagory);

                return RedirectToAction(nameof(Index));
            }

            return View(catagory);
        }
    }
}