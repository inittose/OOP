using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Проводит валидацию входных данных.
    /// </summary>
    static internal class ValueValidator
    {
        /// <summary>
        /// Проверка, превышает ли строка максимальную длину.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        static public void AssertStringOnLength(string value, int maxLength, string propertyName)
        {
            if (value.Length > maxLength)
            {
                throw new 
                    ArgumentException($"{propertyName} должно быть меньше {maxLength} символов.");
            }
        }
    }
}
