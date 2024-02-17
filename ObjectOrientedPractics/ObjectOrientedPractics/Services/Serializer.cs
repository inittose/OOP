using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Сериализует и десериализует данные товаров и покупателей.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Путь до файла сериализации.
        /// </summary>
        private static readonly String _filePath = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), 
            "ObjectOrientedPractics\\Serialization.json");

        /// <summary>
        /// Данные о товарах в json формате.
        /// </summary>
        private static String _itemsJson;

        /// <summary>
        /// Данные о покупателях в json формате.
        /// </summary>
        private static String _customersJson;

        /// <summary>
        /// Возвращает путь до файла сериализации.
        /// </summary>
        public static String FilePath
        {
            get => _filePath;
        }

        /// <summary>
        /// Возвращает и задает данные о товарах в json формате.
        /// </summary>
        public static String ItemsJson
        {
            get => _itemsJson;
            set => _itemsJson = value;
        }

        /// <summary>
        /// Возвращает и задает данные о покупателях в json формате.
        /// </summary>
        public static String CustomersJson
        {
            get => _customersJson;
            set => _customersJson = value;
        }

        /// <summary>
        /// Выгрузить данные о товарах и покупателях из файла сериализации, если он есть.
        /// </summary>
        static Serializer()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            try
            {
                var jsonData = File.ReadAllText(FilePath).Split('\n');
                ItemsJson = jsonData[0];
                CustomersJson = jsonData[1];
            }
            catch
            {
                ItemsJson = String.Empty;
                CustomersJson = String.Empty;
            }
        }

        /// <summary>
        /// Десериализовать данные о товарах.
        /// </summary>
        /// <returns>Список экзепляров класса <see cref="Item"/>.</returns>
        public static List<Item> GetItems()
        {
            if (ItemsJson == String.Empty)
            {
                return new List<Item>();
            }
            else
            {
                var items = JsonConvert.DeserializeObject<List<Item>>(ItemsJson);
                return items;
            }
        }

        /// <summary>
        /// Сериализовать данные о товарах и сохранить изменения.
        /// </summary>
        /// <param name="items">Список экзепляров класса <see cref="Item"/>.</param>
        public static void SetItems(List<Item> items)
        {
            ItemsJson = JsonConvert.SerializeObject(items);
            SaveFile();
        }

        /// <summary>
        /// Десериализовать данные о покупателях.
        /// </summary>
        /// <returns>Список экзепляров класса <see cref="Customer"/>.</returns>
        public static List<Customer> GetCustomers()
        {
            if (CustomersJson == String.Empty)
            {
                return new List<Customer>();
            }
            else
            {
                var customers = JsonConvert.DeserializeObject<List<Customer>>(CustomersJson);
                return customers;
            }
        }

        /// <summary>
        /// Сериализовать данные о покупателях и сохранить изменения.
        /// </summary>
        /// <param name="customer">Список экзепляров класса <see cref="Customer"/>.</param>
        public static void SetCustomers(List<Customer> customer)
        {
            CustomersJson = JsonConvert.SerializeObject(customer);
            SaveFile();
        }

        /// <summary>
        /// Сохранить изменения данных о товарах и покупателях в файл сериализации.
        /// </summary>
        private static void SaveFile()
        {
            File.WriteAllText(FilePath, ItemsJson + "\n" + CustomersJson);
        }
    }
}
