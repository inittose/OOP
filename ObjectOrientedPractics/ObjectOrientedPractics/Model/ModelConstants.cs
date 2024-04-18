namespace ObjectOrientedPractices.Model
{
    /// <summary>
    /// Хранит константы классов Model.
    /// </summary>
    public static class ModelConstants
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
        // TODO: не используется. Убрать
        // UPD: Начало использоваться
        public const int IncreasingDiscount = 1;

        /// <summary>
        /// Количество денежных единиц необходимое для повышения скидки.
        /// </summary>
        public const int AmountForIncreasing = 1000;

        /// <summary>
        /// Минимальное количество накопительных баллов.
        /// </summary>
        public const int MinimumPoints = 0;

        /// <summary>
        /// Максимальное количество скидки от суммы товаров в процентах.
        /// </summary>
        // TODO: грамматическая ошибка Percent
        public const int MaximumDiscountPercent = 30;

        /// <summary>
        /// Количество процентов от суммы заказа, которое будет начисленно на накопительный счет.
        /// </summary>
        // TODO: грамматическая ошибка Percent
        public const int CumulativePercent = 10;
        /// <summary>
        /// Разряд почтового индекса.
        /// </summary>
        public const int IndexDigit = 6;

        /// <summary>
        /// Максимальное число символов названия страны.
        /// </summary>
        public const int CountryLengthLimit = 50;

        /// <summary>
        /// Максимальное число символов названия города.
        /// </summary>
        public const int CityLengthLimit = 50;

        /// <summary>
        /// Максимальное число символов названии улицы.
        /// </summary>
        public const int StreetLengthLimit = 100;

        /// <summary>
        /// Максимальное число символов номера дома.
        /// </summary>
        public const int BuildingLengthLimit = 10;

        /// <summary>
        /// Максимальное число символов номера квартиры/помещения.
        /// </summary>
        public const int ApartmentLengthLimit = 10;

        /// <summary>
        /// Максимальное число символов имени покупателя.
        /// </summary>
        public const int FullnameLengthLimit = 200;

        /// <summary>
        /// Максимальное число символов именования товара.
        /// </summary>
        public const int NameLengthLimit = 200;

        /// <summary>
        /// Максимальное число символов описания товара.
        /// </summary>
        public const int InfoLengthLimit = 1000;

        /// <summary>
        /// Минимальная цена товара.
        /// </summary>
        public const decimal MinimumCost = 0M;

        /// <summary>
        /// Максимальная цена товара.
        /// </summary>
        public const decimal MaximumCost = 100000M;
    }
}
