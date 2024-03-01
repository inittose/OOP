using System;
using System.IO;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Генерирует экзепляр класса <see cref="Item"/> из базы данных.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// Максимальное количество строк в базе данных.
        /// </summary>
        private const int MAX_ROWS = 100;

        /// <summary>
        /// Путь до базы данных товаров.
        /// </summary>
        private static string FileName { get; } = $@"..\..\Services\Databases\ItemsData.txt";

        /// <summary>
        /// Возвращает экзепляр класса <see cref="Item"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Item"/>.</returns>
        public static Item GetRandomItem()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MAX_ROWS);

            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var itemName = randomData[0];
            var itemCost = float.Parse(randomData[1]);
            var itemInfo = randomData[2];
            var randomCategory = (Category)random.Next(0, Enum.GetNames(typeof(Category)).Length);

            var randomItem = new Item(itemName, itemInfo, itemCost, randomCategory);
            return randomItem;
        }
    }
}
