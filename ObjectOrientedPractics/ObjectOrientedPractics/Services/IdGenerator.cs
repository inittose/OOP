namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит и возвращает уникальный идентификатор.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Счетчик уникальных идентификаторов.
        /// </summary>
        private static int Counter { get; set; } = 0;

        /// <summary>
        /// Возвращает уникальный идентификатор и вычисляет новый.
        /// </summary>
        /// <returns>Текущий уникальный идентификатор.</returns>
        public static int GetNextId()
        {
            return Counter++;
        }
    }
}
