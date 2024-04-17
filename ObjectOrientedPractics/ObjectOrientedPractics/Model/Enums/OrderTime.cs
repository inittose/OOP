namespace ObjectOrientedPractices.Model.Enums
{
    /// <summary>
    /// Перечисление времени доставки.
    /// </summary>
    public enum OrderTime
    {
        // TODO: не хватает точек в концах комментарий
        /// <summary>
        /// 9:00 - 11:00.
        /// </summary>
        FromNineToElevenAM,

        /// <summary>
        /// 11:00 - 13:00.
        /// </summary>
        FromElevenToOnePM,

        /// <summary>
        /// 13:00 - 15:00.
        /// </summary>
        FromOneToThreePM,

        /// <summary>
        /// 15:00 - 17:00.
        /// </summary>
        FromThreeToFivePM,

        /// <summary>
        /// 17:00 - 19:00.
        /// </summary>
        FromFiveToSevenPM,

        /// <summary>
        /// 19:00 - 21:00.
        /// </summary>
        FromSevenToNinePM
    }
}
