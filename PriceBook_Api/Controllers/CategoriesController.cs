using Microsoft.AspNetCore.Mvc;
using PriceBook_Data;

namespace PriceBook_Api.Controllers
{
    [Route("api/PriceBook/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet] 
        public IEnumerable<Category> GetCategories()
        {
            Categories cats = new Categories();
            return cats;

        }
    }


}
