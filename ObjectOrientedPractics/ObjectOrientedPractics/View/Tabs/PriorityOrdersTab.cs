using ObjectOrientedPractics.Model;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class PriorityOrdersTab : UserControl
    {
        /// <summary>
        /// Возвращает и задает список товаров.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возвращает и задает приоритетный заказ покупателя.
        /// </summary>
        public PriorityOrder PriorityOrder { get; set; }


        /// <summary>
        /// Создает экзепляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public PriorityOrdersTab()
        {
            InitializeComponent();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            AddressControl.IsTextBoxesEnabled = false;
        }

        /// <summary>
        /// Событие при выборе другого статуса заказа.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
