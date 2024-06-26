﻿using Newtonsoft.Json;
using ObjectOrientedPractices.Services;
using System;
using System.Collections.Generic;
using ObjectOrientedPractices.Model.Enums;

namespace ObjectOrientedPractices.Model.Orders
{
    /// <summary>
    /// Хранит данные о заказе.
    /// </summary>
    public class Order : IEquatable<Order>
    {
        /// <summary>
        /// Возвращает уникальный идентификатор заказа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Возвращает и задает адрес доставки.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Возвращает и задает адрес доставки.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Суммарная скидка заказа.
        /// </summary>
        public decimal DiscountAmount { get; }

        /// <summary>
        /// Возвращает общую стоимость товаров в заказе.
        /// </summary>
        public decimal Amount => ItemsTool.GetAmount(Items);


        /// <summary>
        /// Возвращает конечную стоимость заказа.
        /// </summary>
        public decimal Total => Amount - DiscountAmount;

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        public Order() 
        {
            Id = IdGenerator.GetNextId();
            Status = OrderStatus.New;
            Address = new Address();
            Items = new List<Item>();
            DiscountAmount = 0;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Список товаров заказа.</param>
        /// <param name="discountAmount">Размер скидки заказа.</param>
        public Order(OrderStatus status, Address address, List<Item> items, decimal discountAmount)
        {
            Id = IdGenerator.GetNextId();
            Status = status;
            Address = address;
            Items = items;
            DiscountAmount = discountAmount;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="discountAmount">Размер скидки.</param>
        [JsonConstructor]
        public Order(int id, DateTime date, decimal discountAmount)
        {
            Id = id;
            CreationDate = date;
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

            return GetHashCode() == other.GetHashCode();
        }

        /// <summary>
        /// Возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Id.GetHashCode() + CreationDate.GetHashCode() +
                Status.GetHashCode() + Items.GetHashCode() + DiscountAmount.GetHashCode();

                return hash;
            }
        }
    }
}
