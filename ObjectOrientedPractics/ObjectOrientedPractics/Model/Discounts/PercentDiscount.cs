using Newtonsoft.Json;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model.Discounts
{
    /// <summary>
    /// Хранит и вычисляет процентную скидку на конкретную категорию товаров.
    /// </summary>
    public class PercentDiscount : IDiscount, IComparable<PercentDiscount>
    {
        /// <summary>
        /// Скидка в процентах.
        /// </summary>
        private int _discount;

        /// <summary>
        /// Возвращает и задает скидку в процентах.
        /// Скидка должна быть не менее 1% и не более 10%.
        /// </summary>
        public int Discount
        {
            get => _discount;
            private set
            {
                ValueValidator.AssertIntOnLimits(value, 1, 10, nameof(Discount));
                _discount = value;
            }
        }

        /// <summary>
        /// Возвращает категорию товара, на которую действует скидка.
        /// </summary>
        public Category Category { get; }

        /// <summary>
        /// Возвращает сумму, на которую покупатель уже сделал покупки данной категории товаров.
        /// </summary>
        public double SpendingPerCategory { get; private set; } = 0;

        /// <summary>
        /// Информация о скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Процентная \"{Category}\" - {Discount}%";
            }
        }

        /// <summary>
        /// Вычисляет размер скидки, доступный для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Calculate(List<Item> items)
        {
            var amount = ItemsTool.GetAmountOnCategory(items, Category);
            return amount * Discount / 100;
        }

        /// <summary>
        /// Применяет скидку, доступную для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Apply(List<Item> items)
        {
            return Calculate(items);
        }

        /// <summary>
        /// Обновляет процент скидки на основе полученного списка товаров.
        /// Каждые 1000 рублей, на которую покупатель совершает покупки, 
        /// скидка увеличивается на 1%.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = ItemsTool.GetAmountOnCategory(items, Category);
            SpendingPerCategory += amount;
            var percentage = (int)(SpendingPerCategory / 1000) + 1;

            if (percentage > 10)
            {
                Discount = 10;
            }
            else
            {
                Discount = percentage;
            }
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Категория товара, на которую действует скидка.</param>
        public PercentDiscount(Category category) 
        { 
            Category = category;
            Discount = 1;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Категория товара, на которую действует скидка.</param>
        /// <param name="discount">Размер скидки в процентах.</param>
        /// <param name="spendingPerCategory">Размер потраченных денег на категорию.</param>
        [JsonConstructor]
        private PercentDiscount(Category category, int discount, double spendingPerCategory)
        {
            Category = category;
            Discount = discount;
            SpendingPerCategory = spendingPerCategory;
        }

        /// <summary>
        /// Сравнивает исходный объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="PercentDiscount"/>.</param>
        /// <returns>
        /// 0 - Если размер скидки равен;
        /// 1 - Если у исходного объекта скидка больше;
        /// -1 - Если у передаваемого объекта скидка больше.
        /// </returns>
        public int CompareTo(PercentDiscount other)
        {
            if (this.Discount == other.Discount)
            {
                return 0;
            }
            else if (this.Discount > other.Discount)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
