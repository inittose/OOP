using System;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Проводит валидацию входных данных.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверка, превышает ли строка максимальную длину.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertStringOnLength(string value, int maxLength, string propertyName)
        {
            if (value.Length > maxLength)
            {
                throw new 
                    ArgumentException($"{propertyName} должно быть меньше {maxLength} символов.");
            }
        }

        /// <summary>
        /// Проверка, входит ли вещественное число в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="maximum">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertFloatOnLimits(float value, float minimum, 
            float maximum, string propertyName)
        {
            if (value < minimum || value > maximum)
            {
                throw new 
                    ArgumentException(
                    $"{propertyName} не входит в границы от {minimum} до {maximum}.");
            }
        }

        /// <summary>
        /// Проверка, состоит ли целое число из нужного числа разрядов.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="digit">Число разрядов.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertIntOnDigit(int value, int digit, string propertyName)
        {
            if (value.ToString().Length != digit)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} должно состоять из {digit} разрядов.");
            }
        }
    }
}
