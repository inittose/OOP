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
        private static int _counter = 0;

        /// <summary>
        /// Возвращает и задает счетчик уникальных идентификаторов.
        /// </summary>
        private static int Counter
        {
            get => _counter;
            set => _counter = value;
        }

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
