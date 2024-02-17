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
        private static readonly int _maxRows = 1000;

        /// <summary>
        /// Путь до базы данных покупателей.
        /// </summary>
        private static readonly String _fileName =
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\CustomersData.txt";

        /// <summary>
        /// Возвращает максимальное количество строк в базе данных.
        /// </summary>
        private static int MaxRows
        {
            get => _maxRows;
        }

        /// <summary>
        /// Возвращает путь до базы данных покупателей.
        /// </summary>
        private static String FileName
        {
            get => _fileName;
        }

        /// <summary>
        /// Получить экзепляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Customer"/>.</returns>
        public static Customer GetRandomCustomer()
        {
            var random = new Random();
            var randomIndex = random.Next(0, MaxRows);

            var randomData = File.ReadAllLines(FileName)[randomIndex].Split('\t');
            var customerFullName = randomData[0] + ' ' +  randomData[1];
            var customerAddress = randomData[2];

            Customer randomCustomer = new Customer(customerFullName, customerAddress);
            return randomCustomer;
        }
    }
}
