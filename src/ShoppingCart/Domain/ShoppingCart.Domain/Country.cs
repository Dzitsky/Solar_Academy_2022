namespace ShoppingCart.Domain
{
    /// <summary>
    /// Страна.
    /// </summary>
    public class Country
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
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Товары, произведённые в стране.
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}