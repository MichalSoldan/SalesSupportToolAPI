using Microsoft.AspNetCore.Mvc;

namespace SalesSupportTool.Api.Controllers
{
    public class ApolloIOController : Controller
    {
        public ApolloIOController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
