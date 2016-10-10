using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BarLocatorService.Controllers
{
    [Route("api/")]
    public class BarLocationController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
