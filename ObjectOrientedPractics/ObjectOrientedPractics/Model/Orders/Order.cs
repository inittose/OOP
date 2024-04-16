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
        /// TODO: грамм ошибка
        /// Уникальный индентификатор заказа.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        [JsonProperty]
        private readonly DateTime _date = DateTime.Now;

        /// <summary>
        /// TODO: грамм ошибки
        /// Возвращает уникальный индентификатор заказа.
        /// </summary>
        // TODO: Убери поля, дополни JSON конструктор всеми свойствами. Должно работать точно также
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
        /// TODO: грамм ошибка
        /// Возращает и задает адрес доставки.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// TODO: грамм ошибка
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
        /// TODO: в одну строку.
        public decimal Amount
        {
            get
            {
                return ItemsTool.GetAmount(Items);
            }
        }

        /// <summary>
        /// TODO: грамм ошибка
        /// Возращает конечную стоимость заказа.
        /// </summary>
        /// TODO: в одну строку.
        public decimal Total
        {
            get
            {
                return Amount - DiscountAmount;
            }
        }

        /// <summary>
        /// TODO: грамм ошибка
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
        /// TODO: грамм ошибка
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
        /// TODO: грамм ошибка
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
        /// <returns>Возвращает булево значение, равны ли объекты.</returns>
        public bool Equals(Order other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // TODO: Для того, чтобы использовать корректно GetHashCode,...
            // его нужно переопределить в нужном классе...
            // и на основе всех значений объекта искать Hash
            return GetHashCode() == other.GetHashCode();
        }
    }
}
