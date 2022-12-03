using CollegeTrackerModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeTracker.Controllers
{
    public class CollegeDetailsController : Controller
    {
        // GET: CollegeDetails  
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("getcollegelist")]
        public ActionResult GetCollegeList()
        {
            var list = new List<CollegeTrackerModels.CollegeDetails>();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = httpClient.GetAsync("http://localhost:59866/api/" + "CollegeDetails/GetAllCollegeDetails/").Result;
            response.EnsureSuccessStatusCode();
            List<CollegeDetails> cd = response.Content.ReadAsAsync<List<CollegeDetails>>().Result;
            return View("~/Views/CollegeDetails/CollegeDetails.cshtml", cd);
        }
    }
}