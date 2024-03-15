using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Описывает корзину товаров покупателя.
    /// </summary>
    public class Cart : ICloneable
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

        /// <summary>
        /// Создает копию объекта <see cref="Cart"/>.
        /// </summary>
        /// <returns>Копия объекта в <see cref="object"/>.</returns>
        public object Clone()
        {
            var cart = new Cart();

            foreach(var item in this.Items)
            {
                cart.Items.Add((Item)item.Clone());
            }

            return cart;
        }
    }
}
