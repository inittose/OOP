using System;
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
        private static string FilePath { get; } = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData),
            "ObjectOrientedPractics\\Serialization.json");

        /// <summary>
        /// Данные о товарах и покупателях в json формате.
        /// </summary>
        private static string StoreJson { get; set; } = string.Empty;

        /// <summary>
        /// Выгружает данные о товарах и покупателях из файла сериализации, если он есть.
        /// </summary>
        static Serializer()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            try
            {
                StoreJson = File.ReadAllText(FilePath);
            }
            catch
            {
                StoreJson = string.Empty;
            }
        }

        /// <summary>
        /// Десериализует данные о товарах и покупателях.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Store"/>.</returns>
        public static Store GetStore()
        {
            if (StoreJson == string.Empty)
            {
                return new Store();
            }
            else
            {
                return JsonConvert.DeserializeObject<Store>(StoreJson);
            }
        }

        /// <summary>
        /// Сериализует данные о товарах и покупателях и сохранить изменения.
        /// </summary>
        /// <param name="store">Экзепляр класса <see cref="Store"/>.</param>
        public static void SetStore(Store store)
        {
            StoreJson = JsonConvert.SerializeObject(store);
            SaveFile();
        }

        /// <summary>
        /// Сохранить изменения данных о товарах и покупателях в файл сериализации.
        /// </summary>
        private static void SaveFile()
        {
            File.WriteAllText(FilePath, StoreJson);
        }
    }
}
