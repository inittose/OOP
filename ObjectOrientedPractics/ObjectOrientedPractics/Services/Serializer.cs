using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using ObjectOrientedPractices.Model;

namespace ObjectOrientedPractices.Services
{
    /// <summary>
    /// Сериализует и десериализует данные товаров и покупателей.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Возвращает путь до файла сериализации.
        /// </summary>
        private static string FilePath { get; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ObjectOrientedPractics\\Serialization.json");

        /// <summary>
        /// Возвращает и задает данные о товарах и покупателях в json формате.
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
            // TODO: лишняя вложенность. Тут не нужно писать else. Можешь сразу код писать
            // UPD: +
            try
            {
                return JsonConvert.DeserializeObject<Store>(
                    StoreJson,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
            }
            catch
            {
                StoreJson = string.Empty;
                MessageBox.Show("Data is corrupted.\nSave files have been cleared.");

                return new Store();
            }
        }

        /// <summary>
        /// Сериализует данные о товарах и покупателях и сохранить изменения.
        /// </summary>
        /// <param name="store">Экзепляр класса <see cref="Store"/>.</param>
        public static void SetStore(Store store)
        {
            StoreJson = JsonConvert.SerializeObject(
                store, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            SaveFile();
        }

        /// <summary>
        /// Сохраняет изменения данных о товарах и покупателях в файл сериализации.
        /// </summary>
        private static void SaveFile()
        {
            File.WriteAllText(FilePath, StoreJson);
        }
    }
}
