using Newtonsoft.Json;
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
        /// Уникальный индентификатор заказа.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        [JsonProperty]
        private readonly DateTime _date = DateTime.Now;

        /// <summary>
        /// Возвращает уникальный индентификатор заказа.
        /// </summary>
        public int Id
        {
            get => _id;
        }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime CreationDate
        {
            get => _date;
        }

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
                return ItemsTool.GetAmount(Items);
            }
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        public Order() 
        {
            _id = IdGenerator.GetNextId();
            Status = OrderStatus.New;
            Address = new Address();
            Items = new List<Item>();
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        public Order(OrderStatus status, Address address, List<Item> items)
        {
            _id = IdGenerator.GetNextId();
            Status = status;
            Address = address;
            Items = items;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        [JsonConstructor]
        public Order(int id)
        {
            _id = id;
        }
    }
}
