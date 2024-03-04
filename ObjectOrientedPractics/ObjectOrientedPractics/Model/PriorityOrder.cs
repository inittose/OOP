using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о приоритетном заказе.
    /// </summary>
    public class PriorityOrder : Order
    {
        /// <summary>
        /// Возвращает и задает дату доставки.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Возвращает и задает время доставки.
        /// </summary>
        public OrderTime Time { get; set; }

        /// <summary>
        /// Создает экзепляр класса <see cref="PriorityOrder"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        public PriorityOrder(
            OrderStatus status, 
            Address address, 
            List<Item> items) : base(status, address, items)
        {

        }
    }
}
