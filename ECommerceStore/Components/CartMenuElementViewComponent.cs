using ECommerceStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Components
{
    public class CartMenuElementViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartMenuElementViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
