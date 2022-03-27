using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
