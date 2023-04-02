using Microsoft.AspNetCore.Mvc;
using SADZFP.domain.Catalog;

namespace SADZFP.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

    }
}  
 public class HTTPGetController : Controller
{  
    [HttpGet("/catalog")]
    public IActionResult GetItems()
    {
        return Ok("hello world.");
    }
}