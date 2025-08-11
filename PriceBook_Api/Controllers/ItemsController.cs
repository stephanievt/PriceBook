using Microsoft.AspNetCore.Mvc;
using PriceBook_Data;

namespace PriceBook_Api.Controllers
{
    [Route("api/PriceBook/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        [HttpGet("{catId}")]
        public IEnumerable<Item> Get(int catId)
        {
            Items items = new Items(catId);
            return items.ToList();
        }
    }
}
