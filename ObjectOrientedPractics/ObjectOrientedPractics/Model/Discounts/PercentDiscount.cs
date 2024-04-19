using Newtonsoft.Json;
using ObjectOrientedPractices.Model.Enums;
using ObjectOrientedPractices.Services;
using System;
using System.Collections.Generic;

namespace ObjectOrientedPractices.Model.Discounts
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
        /// TODO: неизвестный MinimumPercent. Сошлись тогда на <класс констант>.MinimumPercent
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
                    ModelConstants.MinimumPercent,
                    ModelConstants.MaximumPercent,
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
        public string Info => $"Процентная \"{Category}\" - {Discount}%";

        /// <summary>
        /// Создает экзепляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Категория товара, на которую действует скидка.</param>
        public PercentDiscount(Category category)
        {
            Category = category;
            Discount = ModelConstants.MinimumPercent;
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

        /// <summary>
        /// Вычисляет размер скидки, доступный для списка товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public decimal Calculate(List<Item> items)
        {
            var amount = ItemsTool.GetAmountOnCategory(items, Category);
            var percents = 100;
            return amount * Discount / percents;
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
        /// Каждые <see cref="ModelConstants.AmountForIncreasing"/> денежных единиц,
        /// на которую покупатель совершает покупки,
        /// скидка увеличивается на <see cref="ModelConstants.AmountForIncreasing"/> процентов.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = ItemsTool.GetAmountOnCategory(items, Category);
            SpendingPerCategory += amount;

            var percentage =
                (int)(SpendingPerCategory / ModelConstants.AmountForIncreasing) +
                ModelConstants.IncreasingDiscount;

            if (percentage > ModelConstants.MaximumPercent)
            {
                Discount = ModelConstants.MaximumPercent;
            }
            else
            {
                Discount = percentage;
            }
        }
    }
}
