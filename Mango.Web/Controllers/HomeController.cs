using System.Diagnostics;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductSevice _productSevice;

        public HomeController(ILogger<HomeController> logger, IProductSevice productSevice)
        {
            _logger = logger;
            _productSevice = productSevice;
        }

        public async IActionResult Index()
        {
            List<ProductDto> list = new();
            var response = await _productSevice.GetAllProductsAsync()
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}