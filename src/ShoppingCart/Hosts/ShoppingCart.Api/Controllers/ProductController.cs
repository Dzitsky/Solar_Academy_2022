using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.AppServices.Product.Services;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers;

/// <summary>
/// Работа с корзиной товаров.
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll(int take, int skip, CancellationToken cancellation)
    {
        var result = await _productService.GetAll(take, skip, cancellation);

        return Ok(result);
    }
}