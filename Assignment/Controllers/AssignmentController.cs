using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Assignment.Controllers
{
    public class AssignmentController : ApiController
    {
        // GET: Assignment
        [HttpGet]
        [Route ("api/Assignment/GetISO8601Format")]
        public IHttpActionResult GetISO8601Format()
        {
            try
            {
                var newTime = DateTime.Now.Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                return Json(newTime);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Assignment/GetProducts")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                ProductService productService = new ProductService();
                return Json(productService.GetProducts());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Assignment/ReadMinima")]
        public async Task<IHttpActionResult> ReadMinima()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ////Deserializing the response recieved from web api and storing into the Employee list
                    List<Root> EmpInfo = JsonConvert.DeserializeObject<List<Root>>(EmpResponse);
                    var d = EmpInfo.Where(s => s.body.Contains("minima")).ToList();
                    return Json(d);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult PostRequest(Guid product_id, int quantity)
        {
            try
            {
                ProductService productService = new ProductService();
                return Json(productService.GetProductById(product_id, quantity));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}