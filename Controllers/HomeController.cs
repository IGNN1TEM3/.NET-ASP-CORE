using Microsoft.AspNetCore.Mvc;
 
namespace WEB_253502_BARANOVSKY.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
