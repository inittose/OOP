using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Описывает корзину товаров покупателя.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Список товаров <see cref="Item"/> в корзине.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возвращает общую стоимость товаров в корзине.
        /// </summary>

        public float Amount
        {
            get
            {
                if (Items == null)
                {
                    return 0f;
                }

                var total = 0f;
                foreach (var item in Items)
                {
                    total += item.Cost;
                }
                return total;
            }
        }
    }
}
