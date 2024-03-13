using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Отвечает за логику работы вкладки заказов покупателей.
    /// </summary>
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Возвращает и задает покупателей.
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Возвращает список заказов.
        /// </summary>
        private List<Order> Orders { get; } = new List<Order>();

        /// <summary>
        /// Создает экзепляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            AddressControl.IsTextBoxesEnabled = false;
        }

        /// <summary>
        /// Обновляет данные вкладки заказов <see cref="OrdersTab"/>.
        /// </summary>
        public void RefreshData()
        {
            UpdateOrders();
        }

        /// <summary>
        /// Обновляет данные таблицы заказов <see cref="OrdersDataGridView"/>.
        /// </summary>
        private void UpdateOrders()
        {
            Orders.Clear();
            OrdersDataGridView.Rows.Clear();

            foreach (var customer in Customers)
            {
                var address = $"{customer.Address.Country}, {customer.Address.City}, ";
                address += $"{customer.Address.Street} {customer.Address.Building}, ";
                address += $"{customer.Address.Apartment}";

                foreach (var order in customer.Orders)
                {
                    Orders.Add(order);
                    OrdersDataGridView.Rows.Add(
                        order.Id, order.CreationDate, order.Status, customer.FullName,
                        address, order.Amount);
                }
            }
        }

        /// <summary>
        /// Возвращает список именований товаров.
        /// </summary>
        /// <param name="items">Список товаров <see cref="List{Item}"/>.</param>
        /// <returns>Список именований товаров <see cref="List{string}"/>.</returns>
        private List<string> GetItemNames(List<Item> items)
        {
            var itemNames = new List<string>();
            foreach (var item in items)
            {
                itemNames.Add(item.Name);
            }
            return itemNames;
        }

        /// <summary>
        /// Событие при выборе другого элемента в таблице заказов.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                IdTextBox.Text = string.Empty;
                CreatedTextBox.Text = string.Empty;
                StatusComboBox.SelectedIndex = -1;
                StatusComboBox.Enabled = false;
                AddressControl.Address = null;
                OrderItemsListBox.DataSource = new List<string>();
                AmountLabel.Text = string.Empty;
                return;
            }
            var selectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;

            IdTextBox.Text = Orders[selectedIndex].Id.ToString();
            CreatedTextBox.Text = Orders[selectedIndex].CreationDate.ToString();
            StatusComboBox.SelectedItem = Orders[selectedIndex].Status;
            StatusComboBox.Enabled = true;
            AddressControl.Address = Orders[selectedIndex].Address;
            OrderItemsListBox.DataSource = GetItemNames(Orders[selectedIndex].Items);
            AmountLabel.Text = Orders[selectedIndex].Amount.ToString();
        }

        /// <summary>
        /// Событие при выборе другого статуса заказа.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                return;
            }

            var selectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;
            Orders[selectedIndex].Status = (OrderStatus)StatusComboBox.SelectedItem;
            OrdersDataGridView[2, selectedIndex].Value = 
                Enum.GetName(typeof(OrderStatus), Orders[selectedIndex].Status);
        }
    }
}
