using System;
using System.Collections.Generic;
using ObjectOrientedPractices.Model.Enums;

namespace ObjectOrientedPractices.Model.Orders
{
    /// <summary>
    /// Хранит данные о приоритетном заказе.
    /// </summary>
    public class PriorityOrder : Order
    {
        /// TODO: нигде не используется. Оно нужно?
        /// UPD: Удалил

        /// <summary>
        /// Возвращает и задает время доставки.
        /// </summary>
        public OrderTime DeliveryTime { get; set; }

        /// <summary>
        /// TODO: грамм ошибка
        /// Создает экземпляр класса <see cref="PriorityOrder"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        /// <param name="discountAmount">Скидка заказа.</param>
        public PriorityOrder(
            OrderStatus status, 
            Address address, 
            List<Item> items,
            decimal discountAmount) : base(status, address, items, discountAmount)
        {
        }
    }
}
