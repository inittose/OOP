using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товарах и покупателях.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Список товаров класса <see cref="Customer"/>.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Список покупателей класса <see cref="Customer"/>.
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();

        /// <summary>
        /// Создает экзепляр класса <see cref="Store"/>.
        /// </summary>
        public Store() 
        {

        }
    }
}
