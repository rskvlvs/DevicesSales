using Microsoft.AspNetCore.Mvc;

namespace DevicesSales.Controllers
{
    [Route("")]
    public class HomeController : Controller 
    {
        [HttpGet, Route("")]
        public ActionResult FirstPage()
        {
            return View();
        }
    }
}
