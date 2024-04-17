using System;
using System.IO;
using ObjectOrientedPractices.Model;

namespace ObjectOrientedPractices.Services
{
    /// <summary>
    /// Генерирует экземпляр класса <see cref="Customer"/> из базы данных.
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
        /// TODO: такой путь нельзя делать. Он подымается к исходному коду...
        /// Вместо этого установи в свойствах файлов в Databases Build Action – Content,...
        /// Copy to Output Directory Always. Тогда у тебя будет путь Services\Databases\CustomersData.txt
        /// (потому что путь устанавливается от точки входа в приложение т.е. файла .exe)
        private static string FileName { get; } = $@"Services\Databases\CustomersData.txt";

        /// <summary>
        /// TODO: грамм ошибка
        /// Создает экземпляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Customer"/>.</returns>
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
