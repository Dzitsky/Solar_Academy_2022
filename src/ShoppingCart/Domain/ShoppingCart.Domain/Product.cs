namespace ShoppingCart.Domain;

/// <summary>
/// Товар
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Идентификатор страны-производителя.
    /// </summary>
    public Guid? ProducingCountryId { get; set; }

    /// <summary>
    /// Страна-производитель.
    /// </summary>
    public Country? ProducingCountry { get; set; }

    /// <summary>
    /// Коллекция элементов корзины.
    /// </summary>
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}