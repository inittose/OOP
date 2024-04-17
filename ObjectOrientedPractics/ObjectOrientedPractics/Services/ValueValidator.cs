﻿using System;

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
                    // TODO: у тебя некоторые строки на русском, некоторые на английском. Нужен один язык
                    ArgumentException($"{propertyName} must be less than {maxLength} characters.");
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
