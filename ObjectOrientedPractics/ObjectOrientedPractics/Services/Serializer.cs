using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    static internal class Serializer
    {
        static private readonly String _filePath = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), 
            "ObjectOrientedPractics\\Serialization.json");

        static private String _itemsJson;
        static private String _customersJson;

        static public String FilePath
        {
            get => _filePath;
        }

        static public String ItemsJson
        {
            get => _itemsJson;
            set => _itemsJson = value;
        }

        static public String CustomersJson
        {
            get => _customersJson;
            set => _customersJson = value;
        }

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

        static private void SaveFile()
        {
            File.WriteAllText(FilePath, ItemsJson + "\n" + CustomersJson);
        }

        static public List<Item> GetItems()
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

        static public void SetItems(List<Item> items)
        {
            ItemsJson = JsonConvert.SerializeObject(items);
            SaveFile();
        }

        static public List<Customer> GetCustomers()
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

        static public void SetCustomers(List<Customer> customer)
        {
            CustomersJson = JsonConvert.SerializeObject(customer);
            SaveFile();
        }
    }
}
