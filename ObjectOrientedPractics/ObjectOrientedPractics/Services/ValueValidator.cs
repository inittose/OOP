using ObjectOrientedPractices.Model;
using System;

namespace ObjectOrientedPractices.Services
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
                    ArgumentException($"{propertyName} must be less than {maxLength} characters.");
            }
        }

        /// <summary>
        /// Проверка, входит ли длина строки в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minLength">Минимальная длина строки.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertStringOnLengthLimits(string value, int minLength, int maxLength, string propertyName)
        {
            if (value.Length >= maxLength)
            {
                throw new
                    ArgumentException($"{propertyName} must be less than {maxLength} characters.");
            }
            else if (value.Length <= minLength)
            {
                throw new
                    ArgumentException($"{propertyName} must be greater than {minLength} characters.");
            }
        }

        /// <summary>
        /// Проверка, входит ли вещественное число в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="maximum">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertDecimalOnLimits(
            decimal value,
            decimal minimum,
            decimal maximum, 
            string propertyName)
        {
            if (value < minimum || value > maximum)
            {
                throw new 
                    ArgumentException(
                    $"{propertyName} does not fall within the {minimum} to {maximum} boundary.");
            }
        }

        /// <summary>
        /// Проверка, является ли строка вещественным числом и
        /// входит ли вещественное число в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="maximum">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertStringOnDecimalLimits(
            string value,
            decimal minimum,
            decimal maximum,
            string propertyName)
        {
            decimal parseValue;

            if (!decimal.TryParse(value, out parseValue))
            {
                throw new ArgumentException($"{propertyName} must be a decimal number.");
            }
            else if (parseValue <= ModelConstants.MinimumCost)
            {
                throw new ArgumentException($"Cost must be greater than { minimum }.");
            }
            else if (parseValue > ModelConstants.MaximumCost)
            {
                throw new ArgumentException($"Сost must be less than {maximum}.");
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
                    $"{propertyName} must consist of {digit} digits.");
            }
        }

        /// <summary>
        /// Проверка, входит ли целочисленное значение в заданный нижний предел.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertIntOnLowerLimit(int value, int minimum, string propertyName)
        {
            if (value < minimum)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} must be greater than {minimum}.");
            }
        }

        /// <summary>
        /// Проверка, входит ли целочисленное значение в заданный верхний предел.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="maximum">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertIntOnUpperLimit(int value, int maximum, string propertyName)
        {
            if (value < maximum)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} must be less than {maximum}.");
            }
        }

        /// <summary>
        /// Проверка, входит ли целочисленное значение в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="maximum">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void AssertIntOnLimits(
            int value, 
            int minimum, 
            int maximum, 
            string propertyName)
        {
            if (value < minimum || value > maximum)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} does not fall within the {minimum} to {maximum} boundary.");
            }
        }
    }
}
