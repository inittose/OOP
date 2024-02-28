using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Отвечает за логику работы вкладки с корзиной покупателя.
    /// </summary>
    public partial class CartsTab : UserControl
    {
        /// <summary>
        /// Возращает и задает индекс текущего покупателя.
        /// </summary>
        private int CurrentCustomer { get; set; } = -1;

        /// <summary>
        /// Возращает и задает список покупок.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возращает и задает список покупателей.
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Создает экзепляр класса <see cref="CartsTab"/>.
        /// </summary>
        public CartsTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обновляет данные <see cref="ItemsListBox"/> и <see cref="CustomerComboBox"/>. 
        /// </summary>
        public void RefreshData()
        {
            UpdateItemsListBox();
            UpdateCustomersComboBox();
            UpdateCartListBox();
            for (var i = 0; i < Customers.Count; i++) 
            {
                UpdateCartItems(Customers[i].Cart);
            }
        }

        /// <summary>
        /// Обновляет данные списка товаров <see cref="ItemsListBox"/>.
        /// </summary>
        private void UpdateItemsListBox()
        {
            var itemsData = new List<string>();

            foreach (var item in Items)
            {
                itemsData.Add(item.Name);
            }

            ItemsListBox.DataSource = itemsData;
            ItemsListBox.Enabled = itemsData.Count != 0;
        }

        /// <summary>
        /// Обновляет данные списка покупателей <see cref="CustomerComboBox"/>. 
        /// </summary>
        private void UpdateCustomersComboBox() 
        {
            var customersData = new List<string>();

            foreach (var customer in Customers)
            {
                customersData.Add(customer.FullName);
            }

            CustomerComboBox.DataSource = customersData;
            CustomerComboBox.Enabled = customersData.Count != 0;
            AmountLabel.Text = string.Empty;
            CustomerComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Обновляет данные списка товаров в корзине <see cref="CartListBox"/>. 
        /// </summary>
        /// <param name="nextIndex">Следующий индекс товара из корзины.</param>
        private void UpdateCartListBox(int nextIndex = -1)
        {
            if (CurrentCustomer < 0)
            {
                CartListBox.DataSource = null;
                CartListBox.Enabled = false;
                return;
            }

            var cartsData = new List<string>();
            foreach (var item in Customers[CurrentCustomer].Cart.Items)
            {
                cartsData.Add(item.Name);
            }

            CartListBox.DataSource = cartsData;
            CartListBox.Enabled = cartsData.Count != 0;
            CartListBox.SelectedIndex = nextIndex;

            AmountLabel.Text = Customers[CurrentCustomer].Cart.Amount.ToString();
        }

        /// <summary>
        /// Обновляет данные корзины покупателя.
        /// </summary>
        /// <param name="cart">Коризна покупателя класса <see cref="Cart"/>.</param>
        private void UpdateCartItems(Cart cart)
        {
            for (var i = 0; i < cart.Items.Count; i++)
            {
                foreach (var item in Items)
                {
                    if (cart.Items[i].Id == item.Id && cart.Items[i] != item)
                    {
                        cart.Items[i] = item;
                    }
                }
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки добавления товара в корзину.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddToCartButton_Click(object sender, System.EventArgs e)
        {
            if (CurrentCustomer < 0 || ItemsListBox.SelectedIndex < 0)
            {
                return;
            }

            Customers[CurrentCustomer].Cart.Items.Add(Items[ItemsListBox.SelectedIndex]);
            UpdateCartListBox();
        }

        /// <summary>
        /// Событие при выборе другого элемента в списке покупателей.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CustomerComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CurrentCustomer = CustomerComboBox.SelectedIndex;
            UpdateCartListBox();
        }

        /// <summary>
        /// Событие при нажатии кнопки удаления товара из корзины.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveItemButton_Click(object sender, System.EventArgs e)
        {
            if (CurrentCustomer < 0 || CartListBox.SelectedIndex < 0)
            {
                return;
            }
            var selectedIndex = CartListBox.SelectedIndex;
            Customers[CurrentCustomer].Cart.Items.RemoveAt(selectedIndex);

            if (selectedIndex >= CartListBox.Items.Count - 1)
            {
                selectedIndex -= 1;
            }

            UpdateCartListBox(selectedIndex);
        }

        /// <summary>
        /// Событие при нажатии кнопки очищения корзины.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ClearCartButton_Click(object sender, System.EventArgs e)
        {
            if (CurrentCustomer < 0)
            {
                return;
            }

            Customers[CurrentCustomer].Cart.Items.Clear();
            UpdateCartListBox();
        }

        /// <summary>
        /// Событие при нажатии кнопки создания заказа.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CreateOrderButton_Click(object sender, System.EventArgs e)
        {
            if (CurrentCustomer < 0)
            {
                return;
            }

            Order order = new Order(
                OrderStatus.New, 
                Customers[CurrentCustomer].Address, 
                Customers[CurrentCustomer].Cart.Items,
                DateTime.Now);

            Customers[CurrentCustomer].Orders.Add(order);
            Customers[CurrentCustomer].Cart.Items = new List<Item>();
            UpdateCartListBox();
        }
    }
}
