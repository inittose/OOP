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
        private const int MaxRows = 1000;

        /// <summary>
        /// Минимальное значение почтового индекса.
        /// </summary>
        private const int MinPostIndex = 100000;

        /// <summary>
        /// Максимальное значение почтового индекса.
        /// </summary>
        private const int MaxPostIndex = 999999;

        /// <summary>
        /// Возвращает путь до базы данных покупателей.
        /// </summary>
        private static string FileName { get; } = $@"..\..\Services\Databases\CustomersData.txt";

        /// <summary>
        /// Создает экзепляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Customer"/>.</returns>
        public static Customer GetRandomCustomer()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MaxRows);
            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var customerFullName = randomData[0] + ' ' +  randomData[1];
            var address = randomData[2].Split(',');
            var buildingAndApartment = address[3].Split(' ');
            var customerAddress = new Address(
                GetRandomPostIndex(), 
                address[0], 
                address[1], 
                address[2], 
                buildingAndApartment[2], 
                buildingAndApartment[3]);

            return new Customer(customerFullName, customerAddress);
        }

        /// <summary>
        /// Возвращает случайный почтовый индекс.
        /// </summary>
        /// <returns>Случайный почтовый индекс типа <see cref="int"/>.</returns>
        private static int GetRandomPostIndex()
        {
            var random = new Random();

            return random.Next(MinPostIndex, MaxPostIndex);
        }
    }
}
