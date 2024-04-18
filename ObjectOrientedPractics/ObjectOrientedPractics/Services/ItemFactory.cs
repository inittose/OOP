using System;
using System.IO;
using ObjectOrientedPractices.Model;
using ObjectOrientedPractices.Model.Enums;

namespace ObjectOrientedPractices.Services
{
    /// <summary>
    /// TODO: грамм ошибка посмотри везде слово "экзепляр"
    /// UPD: +
    /// Генерирует экземпляр класса <see cref="Item"/> из базы данных.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// Максимальное количество строк в базе данных.
        /// </summary>
        private const int MaxRows = 100;

        /// <summary>
        /// Возвращает путь до базы данных товаров.
        /// </summary>
        /// TODO: такой путь нельзя делать. Он подымается к исходному коду...
        /// Вместо этого установи в свойствах файлов в Databases Build Action – Content,...
        /// Copy to Output Directory Always. Тогда у тебя будет путь Services\Databases\ItemsData.txt
        /// (потому что путь устанавливается от точки входа в приложение т.е. файла .exe)
        /// UPD: +
        private static string FileName { get; } = $@"Services\Databases\ItemsData.txt";

        /// <summary>
        /// Возвращает экземпляр класса <see cref="Item"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>экземпляр класса <see cref="Item"/>.</returns>
        public static Item GetRandomItem()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MaxRows);
            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var itemName = randomData[0];
            var itemCost = decimal.Parse(randomData[1]);
            var itemInfo = randomData[2];
            var categoryLength = Enum.GetNames(typeof(Category)).Length;
            var randomCategory = (Category)random.Next(0, categoryLength);

            return new Item(itemName, itemInfo, itemCost, randomCategory);
        }
    }
}
