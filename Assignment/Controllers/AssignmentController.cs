using System;
using System.Web.Http;
namespace Assignment.Controllers
{
    public class AssignmentController : ApiController
    {
        // GET: Assignment
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetISO8601Format()
        {
            var newTime = DateTime.Now.Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return Json(newTime);
        }
    }
}