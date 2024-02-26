using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о заказе.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Возвращает уникальный индентификатор заказа.
        /// </summary>
        public int Id { get; } = IdGenerator.GetNextId();

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime CreationDate { get; } = DateTime.Now;

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Возращает и задает адрес доставки.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Возращает и задает адрес доставки.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возвращает общую стоимость товаров в заказе.
        /// </summary>
        public float Amount
        {
            get
            {
                if (Items == null)
                {
                    return 0f;
                }

                var total = 0f;
                foreach (var item in Items)
                {
                    total += item.Cost;
                }
                return total;
            }
        }
    }
}
