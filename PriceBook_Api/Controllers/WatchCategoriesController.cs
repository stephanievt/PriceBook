using Microsoft.AspNetCore.Mvc;
using PriceBook_Data;

namespace PriceBook_Api.Controllers
{
    [Route("api/PriceBook/WatchCategories")]
    [ApiController]
    public class WatchCategoriesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {

            WatchCategories cats = new WatchCategories();
            return cats;

        }
    }
}
