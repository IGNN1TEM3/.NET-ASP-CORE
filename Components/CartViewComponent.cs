using Microsoft.AspNetCore.Mvc;

namespace WEB_253502_BARANOVSKY.Components
{
    public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Логика для получения информации о корзине
        var cartTotal = "00,0 руб";
        var cartItemsCount = 0;

        ViewData["CartTotal"] = cartTotal;
        ViewData["CartItemsCount"] = cartItemsCount;

        return View();
    }
}
}

