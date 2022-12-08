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
    private readonly ILogger<UserController> _logger;

    //private readonly ILogger<string> _stringLogger;

    /// <summary>
    /// Работа с пользователями.
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="logger"></param>
    public UserController(
        IUserService userService, 
        ILogger<UserController> logger
        //, ILoggerFactory factory
        )
    {
        _userService = userService;
        _logger = logger;
        //_stringLogger = factory.CreateLogger<string>();
    }

    /// <summary>
    /// Зарегистрировать пользователя.
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(string login, string password, CancellationToken cancellation)
    {
        var user = await _userService.Register(login, password, cancellation);

        return Created("",new { });
    }

    /// <summary>
    /// Залогинить пользователя.
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Login(string login, string password, CancellationToken cancellation)
    {
        //_logger.LogInformation("Обычный текст, логирование бизнес операции");
        //_logger.LogWarning("Warning");

        //_logger.LogError("Произошла ошибка!");

        //_stringLogger.Log(LogLevel.Error, "_stringLogger!");

        //_logger.LogCritical("Что критичное!!");
        //_logger.LogTrace("Не критично...");

        try
        {
            var token = await _userService.Login(login, password, cancellation);
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}