using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mymvcapp.Models;

namespace mymvcapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

     

        public IActionResult Privacy()
        {
            return View();
        }

      /*  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
      public IActionResult Index()
        {
            throw new DivideByZeroException("divide by zero");
            return View();
        }
      public IActionResult Error()
        {
            var a =HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewData["a"] = "Message :" + a.Error.Message;
            ViewData["b"] = "Source :" + a.Error.Source;
            return View();
        }
    }
}
