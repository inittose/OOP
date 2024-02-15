using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace ObjectOrientedPractics.Services
{
    internal class CustomerFactory
    {
        /// <summary>
        /// Максимальное количество строк в базе данных.
        /// </summary>
        static private int _maxRows = 1000;

        /// <summary>
        /// Путь до базы данных покупателей.
        /// </summary>
        static private String _fileName = 
            $@"{Directory.GetCurrentDirectory()}\..\..\Services\Databases\CustomersData.txt";

        /// <summary>
        /// Получить экзепляр класса <see cref="Customer"/> с начальными случайными значениями.
        /// </summary>
        /// <returns>Экзепляр класса <see cref="Customer"/>.</returns>
        static public Customer GetRandomCustomer()
        {
            var random = new Random();
            var randomIndex = random.Next(0, _maxRows);

            var randomData = File.ReadAllLines(_fileName)[randomIndex].Split('\t');
            var customerFullName = randomData[0] + ' ' +  randomData[1];
            var customerAddress = randomData[2];

            Customer randomCustomer = new Customer(customerFullName, customerAddress);
            return randomCustomer;
        }
    }
}
