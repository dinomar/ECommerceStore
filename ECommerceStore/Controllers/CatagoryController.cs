﻿using ECommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Controllers
{
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
    }
}