using Microsoft.AspNetCore.Mvc;

namespace EwalletAlifTech.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Started");
        }
    }
}
