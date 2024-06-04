using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("/[contoller]")]
[ApiController]
public class ProductsController : ControllerBase {

    private readonly DatabaseContext context;

    public ProductsController(DatabaseContext context) {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts() {
        return this.context.Product.ToList();
    }

}