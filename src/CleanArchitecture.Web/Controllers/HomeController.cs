using Microsoft.AspNetCore.Mvc;

namespace Rel.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
