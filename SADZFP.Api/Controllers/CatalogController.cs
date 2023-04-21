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
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var Item = _db.Items.Find(id);
            if (Item == null)
            { 
                return NotFound();
            }
            
            Item.AddRating(rating);
            _db.SaveChanges();

            return Ok(Item);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id,  [FromBody] Item item)
        { 
            if (id != item.Id)
            {
                return BadRequest();
            }

            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent;

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return ok();
        }
    }
}  