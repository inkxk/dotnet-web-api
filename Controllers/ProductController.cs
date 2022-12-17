using Microsoft.AspNetCore.Mvc;

namespace dotnet_course.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    // ../Product
    public ActionResult<List<string>> GetProducts()
    {
        var products = new List<string>();
        products.Add("ReactJS");
        products.Add("VueJS");
        products.Add("Angular");

        return Ok(products);
    }

    [HttpGet("{id}")]
    // ../Product/1
    public ActionResult<Object> GetProductById(int id)
    {
        return Ok(new { productId = id, productName = $"Product {id}" });
    }

    [HttpGet("search/{id}/{category}")]
    // ../Product/search/12/tech
    public ActionResult<Object> SearchProductById(int id, string category)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category });
    }

    [HttpGet("query")]
    // ../Product/query?id=12&category=tech
    public ActionResult<Object> QueryProductById([FromQuery] int id, [FromQuery] string category)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category });
    }

    [HttpGet("query/{user}")]
    // ../Product/query/inkxk?id=12&category=tech
    public ActionResult<Object> QueryProductByUser([FromQuery] int id, [FromQuery] string category, string user)
    {
        return Ok(new { productId = id, productName = $"Product {id}", category = category, user = user });
    }

    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        return Ok(product);
    }

    // IActionResult ใช้กรณีไม่มี return ค่ากลับ
    [HttpPut("{id}")]
    public ActionResult updateProductById(int id, [FromBody] Product product)
    {
        if (id != product.id)
        {
            return BadRequest();
        }

        if (id != 1111)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpDelete]
    public ActionResult DeleteById(int id)
    {
        if (id != 1111) {
            return NotFound();
        }
        return NoContent();
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}