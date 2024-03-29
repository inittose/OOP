﻿namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Состояние товара.
    /// </summary>
    public enum OrderStatus
    {
        New,
        Processing,
        Assembly,
        Sent,
        Delivered,
        Returned,
        Abandoned
    }
}
