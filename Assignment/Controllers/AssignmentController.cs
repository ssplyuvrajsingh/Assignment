using Assignment.DIServieces.IServices;
using System;
using System.Threading.Tasks;
using System.Web.Http;


namespace Assignment.Controllers
{
    public class AssignmentController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IGeneralService _generalService;

        public AssignmentController(IProductService productService, IGeneralService generalService)
        {
            _productService = productService;
            _generalService = generalService;
        }

        #region General
        [HttpGet, Route("api/Assignment/GetISO8601Format/")]
        public IHttpActionResult GetISO8601Format()
        {
            try
            {
                return Json(_generalService.GetISO8601Format());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet, Route("api/Assignment/ReadMinima")]
        public async Task<IHttpActionResult> ReadMinima()
        {
            try
            {
                return Json(await _generalService.ReadMinima().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        #endregion

        #region Products
        [HttpGet, Route("api/Assignment/GetProducts")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                return Json(_productService.GetProducts());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost, Route("api/Assignment/PostRequest")]
        public IHttpActionResult PostRequest(Guid product_id, int quantity)
        {
            try
            {
                return Json(_productService.GetProductById(product_id, quantity));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        #endregion
    }
}