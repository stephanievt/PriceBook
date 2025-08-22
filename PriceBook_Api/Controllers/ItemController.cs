using Microsoft.AspNetCore.Mvc;
using PriceBook_Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PriceBook_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {


        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            Item item = new Item(id);
            return item;
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
