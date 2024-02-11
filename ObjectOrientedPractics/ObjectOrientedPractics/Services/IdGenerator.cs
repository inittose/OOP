using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит и возвращает уникальный идентификатор.
    /// </summary>
    static internal class IdGenerator
    {
        /// <summary>
        /// Счетчик уникальных идентификаторов.
        /// </summary>
        private static int _counter = 0;

        /// <summary>
        /// Возвращает уникальный идентификатор и вычисляет новый.
        /// </summary>
        /// <returns>Текущий уникальный идентификатор.</returns>
        static public int GetNextId()
        {
            return _counter++;
        }
    }
}
