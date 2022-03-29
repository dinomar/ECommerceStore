using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceStore.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PaymentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}
