using ObjectOrientedPractics.Services;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Описывает корзину товаров покупателя.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Возвращает и задает cписок товаров <see cref="Item"/> в корзине.
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Возвращает общую стоимость товаров в корзине.
        /// </summary>
        public float Amount
        {
            get
            {
                return ItemsTool.GetAmount(Items);
            }
        }
    }
}
