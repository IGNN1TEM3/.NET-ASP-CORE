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

            var items = new List<ListDemo>()
            {
                new ListDemo { Id = 1, Name = "Item 1" },
                new ListDemo { Id = 2, Name = "Item 2" },
                new ListDemo { Id = 3, Name = "Item 3" }
            };

            var lst = new ModeListViewModel(){
                Items = items,
                SelectedItemId = 1
            };

            ViewData["Tlt"] = "Лабораторная работа 2";
            ViewData["mod_lst"] = lst;
            ViewData["lst"] = model;
            return View();
        }
    }
}
