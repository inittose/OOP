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
        /// Делегат сравнения товаров по критерию.
        /// </summary>
        /// <param name="item">Товар класса <see cref="Item"/>.</param>
        /// <returns>Стоил ли поменять товары местами.</returns>
        public delegate bool CompareProperties(Item first, Item second);

        /// <summary>
        /// Фильтрация товаров по заданному методу критерия.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <param name="compare">Метод критерия <see cref="Predicate{Item}"/>.</param>
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

        /// <summary>
        /// Сортировка товаров по заданному методу критерия.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <param name="compare">Метод критерия <see cref="CompareProperties"/>.</param>
        /// <returns>Отсортированный список товаров.</returns>
        public static List<Item> SortItems(List<Item> items, CompareProperties compare)
        {
            var sortedItems = new List<Item>();

            foreach (var item in items)
            {
                sortedItems.Add(item);
            }

            for (var i = 0; i < sortedItems.Count; i++)
            {
                for (var j = 0; j < sortedItems.Count; j++)
                {
                    if (compare(sortedItems[i], sortedItems[j]))
                    {
                        var item = sortedItems[i];
                        sortedItems[i] = sortedItems[j];
                        sortedItems[j] = item;
                    }
                }
            }

            return sortedItems;
        }
    }
}
