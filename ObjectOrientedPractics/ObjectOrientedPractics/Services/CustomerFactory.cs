using System;
using System.IO;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Генерирует экзепляр класса <see cref="Customer"/> из базы данных.
    /// </summary>
    public static class CustomerFactory
    {
        /// <summary>
        /// Максимальное количество строк в базе данных.
        /// </summary>
        private const int MAX_ROWS = 1000;

        /// <summary>
        /// Минимальное значение почтового индекса.
        /// </summary>
        private const int MIN_POST_INDEX = 100000;

        /// <summary>
        /// Максимальное значение почтового индекса.
        /// </summary>
        private const int MAX_POST_INDEX = 999999;

        /// <summary>
        /// Путь до базы данных покупателей.
        /// </summary>
        private static string FileName { get; } =
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\CustomersData.txt";

        /// <summary>
        /// Возвращает экзепляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Customer"/>.</returns>
        public static Customer GetRandomCustomer()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MAX_ROWS);

            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var customerFullName = randomData[0] + ' ' +  randomData[1];
            var address = randomData[2].Split(',');
            var buildingAndApartment = address[3].Split(' ');
            var customerAddress = new Address(GetRandomPostIndex(), address[0], 
                        address[1], address[2], buildingAndApartment[2], buildingAndApartment[3]);

            return new Customer(customerFullName, customerAddress);
        }

        /// <summary>
        /// Возвращает случайный почтовый индекс.
        /// </summary>
        /// <returns>Случайный почтовый индекс типа <see cref="int"/>.</returns>
        private static int GetRandomPostIndex()
        {
            var random = new Random();
            return random.Next(MIN_POST_INDEX, MAX_POST_INDEX);
        }
    }
}
