using Microsoft.AspNetCore.Mvc;
using SADZFP.domain.Catalog;
using SADZFP.Data;

namespace SADZFP.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet("/catalog")]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var Item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            Item.Id = id;

            return Ok(Item);
        }

        [HttpPost("/catalog")]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var Item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            Item.Id = id;
            Item.AddRating(rating);

            return Ok(Item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}  