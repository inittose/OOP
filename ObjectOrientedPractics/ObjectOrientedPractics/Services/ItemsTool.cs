using ObjectOrientedPractics.Model;
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
        public static float GetAmount(List<Item> items)
        {
            if (items == null)
            {
                return 0f;
            }

            var total = 0f;
            foreach (var item in items)
            {
                total += item.Cost;
            }
            return total;
        }
    }
}
