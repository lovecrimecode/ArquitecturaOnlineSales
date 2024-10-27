using Microsoft.AspNetCore.Mvc;

namespace OnlineSales.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
