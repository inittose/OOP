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
        private static readonly int _maxRows = 100;

        /// <summary>
        /// Путь до базы данных товаров.
        /// </summary>
        private static readonly String _fileName =
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\ItemsData.txt";

        /// <summary>
        /// Возвращает максимальное количество строк в базе данных.
        /// </summary>
        private static int MaxRows
        {
            get => _maxRows;
        }

        /// <summary>
        /// Возвращает путь до базы данных товаров.
        /// </summary>
        private static String FileName
        {
            get => _fileName;
        }

        /// <summary>
        /// Получить экзепляр класса <see cref="Item"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Item"/>.</returns>
        public static Item GetRandomItem()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MaxRows);

            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var itemName = randomData[0];
            var itemCost = float.Parse(randomData[1]);
            var itemInfo = randomData[2];

            Item randomItem = new Item(itemName, itemInfo, itemCost);
            return randomItem;
        }
    }
}
