using Microsoft.AspNetCore.Mvc;

namespace dotnet_course.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    // 
    public ActionResult<List<string>> GetProducts()
    {
        var products = new List<string>();
        products.Add("ReactJS");
        products.Add("VueJS");
        products.Add("Angular");

        return Ok(products);
    }

    [HttpGet("{id}")]
    // 
    public ActionResult<Object> GetProductById(int id)
    {
        return Ok(new { productId = id, productName = $"Product {id}" });
    }

    [HttpGet("search/{id}/{category}")]
    // 
    public ActionResult<Object> SearchProductById(int id, string category)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category });
    }

    [HttpGet("query")]
    // 
    public ActionResult<Object> QueryProductById([FromQuery] int id, [FromQuery] string category)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category });
    }

    [HttpGet("query/{user}")]
    // 
    public ActionResult<Object> QueryProductByUser([FromQuery] int id, [FromQuery] string category, string user)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category, user = user });
    }
}
