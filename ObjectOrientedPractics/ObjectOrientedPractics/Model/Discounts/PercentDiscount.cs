﻿using Newtonsoft.Json;
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
        /// Минимально возможная скидка в процентах.
        /// </summary>
        public const int MinimumPercent = 1;

        /// <summary>
        /// Максимально возможная скидка в процентах.
        /// </summary>
        public const int MaximumPercent = 10;

        /// <summary>
        /// Количество процентов, на которое повышается скидка, при выполнении условия.
        /// </summary>
        public const int IncreasingDiscount = 1;

        /// <summary>
        /// Количество денежных единиц необходимое для повышения скидки.
        /// </summary>
        public const int AmountForIncreasing = 1000;

        /// <summary>
        /// Скидка в процентах.
        /// </summary>
        private int _discount;

        /// <summary>
        /// Возвращает и задает скидку в процентах.
        /// Скидка должна быть не менее <see cref="MinimumPercent"/> процентов
        /// и не более <see cref="MaximumPercent"/> процентов.
        /// </summary>
        public int Discount
        {
            get => _discount;
            private set
            {
                ValueValidator.AssertIntOnLimits(
                    value, 
                    MinimumPercent, 
                    MaximumPercent, 
                    nameof(Discount));

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
        public decimal SpendingPerCategory { get; private set; } = 0M;

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
        public decimal Calculate(List<Item> items)
        {
            var amount = ItemsTool.GetAmountOnCategory(items, Category);

            return amount * Discount / 100;
        }

        /// <summary>
        /// Применяет скидку, доступную для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public decimal Apply(List<Item> items)
        {
            return Calculate(items);
        }

        /// <summary>
        /// Обновляет процент скидки на основе полученного списка товаров.
        /// Каждые <see cref="AmountForIncreasing"/> денежных единиц, 
        /// на которую покупатель совершает покупки, 
        /// скидка увеличивается на <see cref="IncreasingDiscount"/> процентов.
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
        private PercentDiscount(Category category, int discount, decimal spendingPerCategory)
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
            if (Discount == other.Discount)
            {
                return 0;
            }
            else if (Discount > other.Discount)
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
