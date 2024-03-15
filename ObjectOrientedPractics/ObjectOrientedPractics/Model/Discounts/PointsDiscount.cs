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
                ValueValidator.AssertIntOnLowerLimit(value, 0, nameof(Points));
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
        /// Скидка товаров не может быть больше 30% от общей суммы товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Calculate(List<Item> items)
        {
            var amount = ItemsTool.GetAmount(items);

            if (Points / amount > 0.3)
            {
                return amount * 0.3;
            }
            else
            {
                return Points;
            }
        }

        /// <summary>
        /// Применяет накопительные баллы на скидку, доступную для списка товаров.
        /// Скидка товаров не может быть больше 30% от общей суммы товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Размер скидки.</returns>
        public double Apply(List<Item> items)
        {
            var discount = Calculate(items);
            Points -= (int)discount;
            return discount;
        }

        /// <summary>
        /// Добавляет баллы на основе полученного списка товаров.
        /// Каждая покупка увеличивает количество накопленных баллов 
        /// на 10% от общей стоимости товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        public void Update(List<Item> items)
        {
            var amount = ItemsTool.GetAmount(items);
            Points += (int)Math.Ceiling(amount * 0.1);
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
            if (this.Points == other.Points)
            {
                return 0;
            }
            else if (this.Points > other.Points)
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
