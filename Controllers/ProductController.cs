using Microsoft.AspNetCore.Mvc;

namespace dotnet_course.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<string>> GetProducts() {
        var products = new List<string>();
        products.Add("ReactJS");
        products.Add("VueJS");
        products.Add("Angular");

        return Ok(products);
    }
}
