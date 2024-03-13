using System.Collections.Generic;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит и возвращает уникальный идентификатор.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Возвращает и задает список занятый уникальных идентификаторов.
        /// </summary>
        public static List<int> BusyIds { get; set; }

        /// <summary>
        /// Возвращает и задает счетчик уникальных идентификаторов.
        /// </summary>
        private static int Counter { get; set; } = 0;

        /// <summary>
        /// Возвращает уникальный идентификатор и вычисляет новый.
        /// </summary>
        /// <returns>Текущий уникальный идентификатор.</returns>
        public static int GetNextId()
        {
            while (BusyIds.Exists(id => id == Counter))
            {
                ++Counter;
            }
            BusyIds.Add(Counter);
            return Counter++;
        }

        /// <summary>
        /// Освобождает уникальный идентификатор.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        public static void ReleaseId(int id)
        {
            BusyIds.Remove(id);
        }
    }
}
