using Newtonsoft.Json;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Orders
{
    /// <summary>
    /// Хранит данные о заказе.
    /// </summary>
    public class Order : IEquatable<Order>
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
        /// Суммарная скидка заказа.
        /// </summary>
        public decimal DiscountAmount { get; }

        /// <summary>
        /// Возвращает общую стоимость товаров в заказе.
        /// </summary>
        public decimal Amount
        {
            get
            {
                return ItemsTool.GetAmount(Items);
            }
        }

        /// <summary>
        /// Возращает конечную стоимость заказа.
        /// </summary>
        public decimal Total
        {
            get
            {
                return Amount - DiscountAmount;
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
            DiscountAmount = 0;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        /// <param name="discountAmount">Размер скидки заказа.</param>
        public Order(OrderStatus status, Address address, List<Item> items, decimal discountAmount)
        {
            _id = IdGenerator.GetNextId();
            Status = status;
            Address = address;
            Items = items;
            DiscountAmount = discountAmount;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="discountAmount">Размер скидки.</param>
        [JsonConstructor]
        public Order(int id, decimal discountAmount)
        {
            _id = id;
            DiscountAmount = discountAmount;
        }

        /// <summary>
        /// Проверяет равенство исходного объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="Order"/>.</param>
        /// <returns>Возвращает булевое значение, равны ли объекты.</returns>
        public bool Equals(Order other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return GetHashCode() == other.GetHashCode();
        }
    }
}
