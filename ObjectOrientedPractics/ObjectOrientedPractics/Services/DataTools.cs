using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Фильтрует и сортирует данные.
    /// </summary>
    public static class DataTools
    {
        /// <summary>
        /// Делегат сравнения свойств товара по критерию.
        /// </summary>
        /// <param name="item">Товар класса <see cref="Item"/>.</param>
        /// <returns>Подходил ли товар под критерий.</returns>
        public delegate bool CompareProperties(Item item);

        /// <summary>
        /// Фильтрация товаров по заданному методу критерия.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <param name="compare">Метод критерия <see cref="CompareProperties"/>.</param>
        /// <returns>Отфильтрованный список товаров.</returns>
        public static List<Item> FilterItems(List<Item> items, Predicate<Item> compare)
        {
            var filteredItems = new List<Item>();

            foreach (var item in items)
            {
                if (compare(item))
                {
                    filteredItems.Add(item);
                }
            }

            return filteredItems;
        }
    }
}
