using System.Collections.Generic;

// TODO: namespace не соответствует реальному расположению
namespace ObjectOrientedPractics.Model.Discounts
{
    /// <summary>
    /// Интерфейс взаимодействия скидок.
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Возвращает информацию о скидке.
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Вычисляет размер скидки, доступный для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        decimal Calculate(List<Item> items);

        /// <summary>
        /// Применяет скидку, доступную для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        decimal Apply(List<Item> items);

        /// <summary>
        /// Обновляет скидку на основе полученного списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        void Update(List<Item> items);
    }
}
