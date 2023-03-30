using Microsoft.AspNetCore.Mvc;
using SADZFP.domain.Catalog;

namespace SADZFP.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok("hello world.");
    }
}