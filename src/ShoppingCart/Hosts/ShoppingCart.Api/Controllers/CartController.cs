using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers;

/// <summary>
/// Работа с корзиной товаров.
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class CartController : ControllerBase
{
    public CartController()
    {
    }

    /// <summary>
    /// Возвращает позиции товаров в корзине.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="ShoppingCartDto"/>.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShoppingCartDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Обновляет количество товара в корзине.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateQuantityAsync(int quantity)
    {
        return await Task.FromResult(Ok());
    }

    /// <summary>
    /// Удаляет товар из корзины.
    /// </summary>
    /// <param name="id">Идентификатор товара в корзине.</param>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await Task.FromResult(Ok());
    }
}