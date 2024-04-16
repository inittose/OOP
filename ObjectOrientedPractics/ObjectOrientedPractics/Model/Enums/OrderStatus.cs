namespace ObjectOrientedPractics.Model.Enums
{
    /// <summary>
    /// Состояние товара.
    /// </summary>
    public enum OrderStatus
    {
        // TODO: не хватает точек в концах комментарий
        /// <summary>
        /// Новый заказ
        /// </summary>
        New,

        /// <summary>
        /// Заказ в обработке
        /// </summary>
        Processing,

        /// <summary>
        /// Сборка заказа
        /// </summary>
        Assembly,

        /// <summary>
        /// Заказ отправлен
        /// </summary>
        Sent,

        /// <summary>
        /// Заказ доставлен
        /// </summary>
        Delivered,

        /// <summary>
        /// Заказ возвращен
        /// </summary>
        Returned,

        /// <summary>
        /// Заказ отменен
        /// </summary>
        Abandoned
    }
}
