using Newtonsoft.Json;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model.Discounts
{
    /// <summary>
    /// Хранит и вычисляет данные о накопительных баллах.
    /// </summary>
    public class PointsDiscount : IDiscount, IComparable<PointsDiscount>
    {
        /// <summary>
        /// Минимальное количество накопительных баллов.
        /// </summary>
        public const int MinimumPoints = 0;

        /// <summary>
        /// Максимальное количество скидки от суммы товаров в процентах.
        /// </summary>
        public const int MaximumDiscountPersent = 30;

        /// <summary>
        /// Количество процентов от суммы заказа, которое будет начисленно на накопительный счет.
        /// </summary>
        public const int CumulativePersent = 10;

        /// <summary>
        /// Накопительные баллы.
        /// </summary>
        private int _points;

        /// <summary>
        /// Возвращает и задает накопительные баллы.
        /// Должно быть неотрицательным числом.
        /// </summary>
        public int Points
        {
            get => _points;
            private set
            {
                ValueValidator.AssertIntOnLowerLimit(value, MinimumPoints, nameof(Points));
                _points = value;
            }
        }

        /// <summary>
        /// Информация о скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Накопительная - {Points} баллов";
            }
        }

        /// <summary>
        /// Вычисляет размер скидки, доступный для списка товаров.
        /// Скидка товаров не может быть больше <see cref="MaximumDiscountPersent"/> процентов
        /// от общей суммы товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public decimal Calculate(List<Item> items)
        {
            var amount = ItemsTool.GetAmount(items);

            if (amount == 0M)
            {
                return 0M;
            }
            if (Points / amount * 100M > MaximumDiscountPersent)
            {
                return amount * MaximumDiscountPersent / 100M;
            }
            else
            {
                return Points;
            }
        }

        /// <summary>
        /// Применяет накопительные баллы на скидку, доступную для списка товаров.
        /// Скидка товаров не может быть больше <see cref="MaximumDiscountPersent"/> процентов 
        /// от общей суммы товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public decimal Apply(List<Item> items)
        {
            var discount = Calculate(items);
            Points -= (int)discount;

            return discount;
        }

        /// <summary>
        /// Добавляет баллы на основе полученного списка товаров.
        /// Каждая покупка увеличивает количество накопленных баллов 
        /// на <see cref="CumulativePersent"/> от общей стоимости товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = ItemsTool.GetAmount(items);
            Points += (int)Math.Ceiling(amount * CumulativePersent / 100M);
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="PointsDiscount"/>.
        /// </summary>
        public PointsDiscount()
        {
            Points = 0;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="PointsDiscount"/>.
        /// </summary>
        /// <param name="points">Размер накопительных баллов.</param>
        [JsonConstructor]
        private PointsDiscount(int points)
        {
            Points = points;
        }

        /// <summary>
        /// Сравнивает исходный объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="PointsDiscount"/>.</param>
        /// <returns>
        /// 0 - Если баллы равны;
        /// 1 - Если у исходного объекта баллов больше;
        /// -1 - Если у передаваемого объекта баллов больше.
        /// </returns>
        public int CompareTo(PointsDiscount other)
        {
            if (Points == other.Points)
            {
                return 0;
            }
            else if (Points > other.Points)
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
