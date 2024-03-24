using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Вычисляет различные характеристики товаров.
    /// </summary>
    public static class ItemsTool
    {
        /// <summary>
        /// Возвращает суммарную стоимость товаров в списке.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <returns>Суммарная стоимость товаров.</returns>
        public static decimal GetAmount(List<Item> items)
        {
            if (items == null)
            {
                return 0M;
            }

            var total = 0M;

            foreach (var item in items)
            {
                total += item.Cost;
            }

            return total;
        }

        /// <summary>
        /// Возвращает суммарную стоимость товаров в списке конкретной категории.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <param name="category">Категория товара <see cref="Category"/>.</param>
        /// <returns>Суммарная стоимость товаров конкретной категории.</returns>
        public static decimal GetAmountOnCategory(List<Item> items, Category category)
        {
            if (items == null)
            {
                return 0M;
            }

            var total = 0M;

            foreach (var item in items)
            {
                if (item.Category == category)
                {
                    total += item.Cost;
                }
            }

            return total;
        }
    }
}
