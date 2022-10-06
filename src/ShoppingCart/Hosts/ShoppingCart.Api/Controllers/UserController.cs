using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.AppServices.ShoppingCart.Services;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers;

/// <summary>
/// Работа с пользователями.
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    ///// <summary>
    ///// Возвращает позиции товаров в корзине.
    ///// </summary>
    ///// <returns>Коллекция элементов <see cref="ShoppingCartDto"/>.</returns>
    //[HttpGet]
    //[ProducesResponseType(typeof(IReadOnlyCollection<ShoppingCartDto>), (int)HttpStatusCode.OK)]
    //public async Task<IActionResult> GetAsync(CancellationToken cancellation)
    //{
    //    var result = await _shoppingCartService.GetAsync(cancellation);
    //    return Ok(result);
    //}
    
    ///// <summary>
    ///// Обновляет количество товара в корзине.
    ///// </summary>
    //[HttpPut("{id}")]
    //[ProducesResponseType((int)HttpStatusCode.NoContent)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //public async Task<IActionResult> UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
    //{
    //    await _shoppingCartService.UpdateQuantityAsync(id, quantity, cancellation);
    //    return NoContent();
    //}

    ///// <summary>
    ///// Удаляет товар из корзины.
    ///// </summary>
    ///// <param name="id">Идентификатор товара в корзине.</param>
    //[HttpDelete]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellation)
    //{
    //    await _shoppingCartService.DeleteAsync(id, cancellation);
    //    return NoContent();
    //}
}