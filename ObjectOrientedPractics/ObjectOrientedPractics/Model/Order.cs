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
        public DateTime CreationDate { get; }

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

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        public Order() 
        {
            Status = OrderStatus.New;
            Address = new Address();
            Items = new List<Item>();
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        /// <param name="creationDate">Дата создания заказа.</param>
        public Order(OrderStatus status, Address address, List<Item> items, DateTime creationDate)
        {
            Status = status;
            Address = address;
            Items = items;
            CreationDate = creationDate;
        }
    }
}
