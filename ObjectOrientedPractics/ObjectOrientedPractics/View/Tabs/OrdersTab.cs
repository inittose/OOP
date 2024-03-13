using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Model.Orders;
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
        /// Флаг, является ли выбранный заказ приоритетным. 
        /// </summary>
        private bool _isPriorityOrder = false;

        /// <summary>
        /// Индекс выбранного заказа.
        /// </summary>
        private int _selectedIndex = -1;

        /// <summary>
        /// Возвращает и задает покупателей.
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Возвращает список заказов.
        /// </summary>
        private List<Order> Orders { get; } = new List<Order>();

        /// <summary>
        /// Возвращает и задает индекс выбранного заказа.
        /// </summary>
        private int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                UpdateAllBoxes();
            }
        }

        /// <summary>
        /// Возвращает и задает флаг, является ли выбранный заказ приоритетным. 
        /// </summary>
        private bool IsPriorityOrder
        {
            get => _isPriorityOrder;
            set
            {
                _isPriorityOrder = value;

                if (value)
                {
                    PriorityOprionPanel.Visible = value;
                    var priorityOrder = (PriorityOrder)Orders[SelectedIndex];
                    DeliveryTimeComboBox.SelectedIndex = (int)priorityOrder.Time;
                }
                else
                {
                    PriorityOprionPanel.Visible = false;
                }
            }
        }
        

        /// <summary>
        /// Создает экзепляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            AddressControl.IsTextBoxesEnabled = false;
            PriorityOprionPanel.Visible = false;
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
                    var index = OrdersDataGridView.Rows.Add( 
                        "", order.Id, order.CreationDate, order.Status, customer.FullName,
                        address, order.Amount);

                    if (order is PriorityOrder)
                    {
                        OrdersDataGridView.Rows[index].Cells[0].Value = "\u2605";
                    }
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
        /// Обновляет данные всех ячеек.
        /// </summary>
        private void UpdateAllBoxes()
        {
            if (SelectedIndex == -1)
            {
                IdTextBox.Text = string.Empty;
                CreatedTextBox.Text = string.Empty;
                StatusComboBox.SelectedIndex = -1;
                StatusComboBox.Enabled = false;
                AddressControl.Address = null;
                OrderItemsListBox.DataSource = new List<string>();
                AmountLabel.Text = string.Empty;
                IsPriorityOrder = false;
            }
            else
            {
                IdTextBox.Text = Orders[SelectedIndex].Id.ToString();
                CreatedTextBox.Text = Orders[SelectedIndex].CreationDate.ToString();
                StatusComboBox.SelectedItem = Orders[SelectedIndex].Status;
                StatusComboBox.Enabled = true;
                AddressControl.Address = Orders[SelectedIndex].Address;
                OrderItemsListBox.DataSource = GetItemNames(Orders[SelectedIndex].Items);
                AmountLabel.Text = Orders[SelectedIndex].Amount.ToString();
                IsPriorityOrder = Orders[SelectedIndex] is PriorityOrder;
            }
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
                SelectedIndex = -1;
            }
            else
            {
                SelectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;
            }
        }

        /// <summary>
        /// Событие при выборе другого статуса заказа.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            Orders[SelectedIndex].Status = (OrderStatus)StatusComboBox.SelectedItem;
            OrdersDataGridView[3, SelectedIndex].Value = 
                Enum.GetName(typeof(OrderStatus), Orders[SelectedIndex].Status);
        }

        /// <summary>
        /// Событие при выборе другого времени доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex == -1 || !IsPriorityOrder)
            {
                return;
            }

            var priorityOrder = (PriorityOrder)Orders[SelectedIndex];
            priorityOrder.Time = (OrderTime)DeliveryTimeComboBox.SelectedIndex;
        }
    }
}
