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
        /// Путь до базы данных покупателей.
        /// </summary>
        private static string FileName { get; } =
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\CustomersData.txt";

        /// <summary>
        /// Получить экзепляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Customer"/>.</returns>
        public static Customer GetRandomCustomer()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MAX_ROWS);

            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var customerFullName = randomData[0] + ' ' +  randomData[1];
            var customerAddress = new Address();//randomData[2];

            var randomCustomer = new Customer(customerFullName, customerAddress);
            return randomCustomer;
        }
    }
}
