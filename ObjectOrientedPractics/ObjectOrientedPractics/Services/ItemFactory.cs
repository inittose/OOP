using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    internal class ItemFactory
    {
        /// <summary>
        /// Максимальное количество строк в базе данных.
        /// </summary>
        static private int _maxRows = 100;

        /// <summary>
        /// Путь до базы данных товаров.
        /// </summary>
        static private String _fileName =
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\ItemsData.txt";

        /// <summary>
        /// Получить экзепляр класса <see cref="Item"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Item"/>.</returns>
        static public Item GetRandomItem()
        {
            var random = new Random();
            var randomIndex = random.Next(0, _maxRows);

            var randomData = File.ReadAllLines(_fileName)[randomIndex].Split('\t');
            var itemName = randomData[0];
            var itemCost = float.Parse(randomData[1]);
            var itemInfo = randomData[2];

            Item randomItem = new Item(itemName, itemInfo, itemCost);
            return randomItem;
        }
    }
}
