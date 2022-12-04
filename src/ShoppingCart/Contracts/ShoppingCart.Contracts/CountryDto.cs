namespace ShoppingCart.Contracts
{
    /// <summary>
    /// Информация о стране.
    /// </summary>
    public class CountryDto
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
    }
}