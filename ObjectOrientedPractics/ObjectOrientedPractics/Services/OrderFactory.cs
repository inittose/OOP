using ObjectOrientedPractices.Model.Orders;
using ObjectOrientedPractices.Model;
using System.Collections.Generic;
using ObjectOrientedPractices.Model.Enums;

namespace ObjectOrientedPractices.Services
{
    /// <summary>
    /// Создает экземпляры класса <see cref="Order"/>.
    /// </summary>
    public static class OrderFactory
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <param name="discountAmount">Размер скидки.</param>
        /// <returns>Экземпляр класса <see cref="Order"/>.</returns>
        public static Order Create(Customer customer, decimal discountAmount)
        {
            var items = new List<Item>();
            Order order;

            foreach (var item in customer.Cart.Items)
            {
                items.Add((Item)item.Clone());
            }

            if (customer.IsPriority)
            {
                order = new PriorityOrder(
                    OrderStatus.New,
                    customer.Address,
                    items,
                    discountAmount);
            }
            else
            {
                order = new Order(
                    OrderStatus.New,
                    customer.Address,
                    items,
                    discountAmount);
            }

            return order;
        }
    }
}
