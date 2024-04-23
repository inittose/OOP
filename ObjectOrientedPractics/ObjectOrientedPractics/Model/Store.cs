using ObjectOrientedPractices.Services;
using System.Collections.Generic;

namespace ObjectOrientedPractices.Model
{
    /// <summary>
    /// Хранит данные о товарах и покупателях.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Возвращает и задает список занятый уникальных идентификаторов.
        /// </summary>
        public List<int> BusyIds { get; set; } = new List<int>();

        /// <summary>
        /// Возвращает и задает список товаров класса <see cref="Customer"/>.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Возвращает и задает список покупателей класса <see cref="Customer"/>.
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();

        /// <summary>
        /// Создает экзепляр класса <see cref="Store"/>.
        /// </summary>
        public Store() 
        {
            IdGenerator.BusyIds = BusyIds;
        }
    }
}
