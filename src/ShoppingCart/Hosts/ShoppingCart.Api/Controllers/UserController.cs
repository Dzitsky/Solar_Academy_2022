using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.AppServices.ShoppingCart.Services;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers;

/// <summary>
/// Работа с пользователями.
/// </summary>
[ApiController]
[AllowAnonymous]
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

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(string login, string password, CancellationToken cancellation)
    {
        var user = await _userService.Register(login, password, cancellation);

        return Created("",new { });
    }


    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Login(string login, string password, CancellationToken cancellation)
    {
        var token = await _userService.Login(login, password, cancellation);

        return Ok(token);
    }




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