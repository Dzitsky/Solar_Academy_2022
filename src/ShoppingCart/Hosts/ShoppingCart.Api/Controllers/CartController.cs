using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.AppServices.ShoppingCart.Services;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers;

/// <summary>
/// Работа с корзиной товаров.
/// </summary>
[ApiController]
[Authorize]
[Route("v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shoppingCartService"></param>
    public CartController(IShoppingCartService shoppingCartService, IUserService userService)
    {
        _shoppingCartService = shoppingCartService;
        _userService = userService;
    }

    /// <summary>
    /// Возвращает позиции товаров в корзине.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="ShoppingCartDto"/>.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShoppingCartDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellation)
    {
        var result = await _shoppingCartService.GetAsync(cancellation);

        return Ok(result);
    }

    /// <summary>
    /// Cоздает корзину.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="ShoppingCartDto"/>.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShoppingCartDto>), StatusCodes.Status201Created)]
    public async Task<IActionResult> PostAsync(CancellationToken cancellation)
    {
        var user = await _userService.GetCurrent(cancellation);
              
        var result = await _shoppingCartService.GetAsync(cancellation);

        return Ok(result);
    }

    /// <summary>
    /// Обновляет количество товара в корзине.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
    {
        await _shoppingCartService.UpdateQuantityAsync(id, quantity, cancellation);
        return NoContent();
    }

    /// <summary>
    /// Удаляет товар из корзины.
    /// </summary>
    /// <param name="id">Идентификатор товара в корзине.</param>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellation)
    {
        await _shoppingCartService.DeleteAsync(id, cancellation);
        return NoContent();
    }
}