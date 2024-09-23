using Microsoft.AspNetCore.Mvc;

namespace WEB_253502_BARANOVSKY.Components
{
    public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var cartTotal = "00,0 руб";
        var cartItemsCount = 0;

        ViewData["CartTotal"] = cartTotal;
        ViewData["CartItemsCount"] = cartItemsCount;

        return View();
    }
}
}

