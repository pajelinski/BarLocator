using System;
using System.Net.Http;
using System.Web.Mvc;

namespace BarLocatorClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNearbyBarLocations()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:5000/")};
            var result = 
                httpClient
                .GetStringAsync("/api/bars/nearby?latitude=50.0618971&longitude=19.9345673&radius=2000")
                .Result;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}