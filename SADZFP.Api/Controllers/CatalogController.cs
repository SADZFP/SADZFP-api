using Microsoft.AspNetCore.Mvc;
using SADZFP.domain.Catalog;

namespace SADZFP.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
    }
        
        [HttpPost("/catalog")]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
}  
 public class HTTPGetController : Controller
{  
    [HttpGet("/catalog")]
    public IActionResult GetItems()
    {
        return Ok("hello world.");
    }
}