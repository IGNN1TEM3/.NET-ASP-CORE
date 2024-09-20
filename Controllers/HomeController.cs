using Microsoft.AspNetCore.Mvc;
using WEB_253502_BARANOVSKY.Models;

namespace WEB_253502_BARANOVSKY.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new ListViewModel(){
                Items = new List<string> {"элемент 1","элемент 2","элемент 3", "элемент 4"}
            };
            return View(model);
        }
    }
}
