using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Model.Orders;
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
        /// Индекс текущего покупателя.
        /// </summary>
        private int _currentCustomer;

        /// <summary>
        /// Возращает и задает индекс текущего покупателя.
        /// </summary>
        private int CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                SetVisible(value >= 0);
                _currentCustomer = value;
            }
        }

        /// <summary>
        /// Возращает и задает список покупок.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возращает и задает список покупателей.
        /// </summary>
        public List<Customer> Customers { get; set; }

        public decimal DiscountAmount { get; set; }

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
            DiscountsCheckedListBox.Items.Clear();
        }

        /// <summary>
        /// Обновляет данные корзин покупателей.
        /// </summary>
        public void UpdateCustomerCarts()
        {
            foreach (var customer in Customers)
            {
                UpdateCartItems(customer.Cart);
            }
        }

        /// <summary>
        /// Устанавливает видимость текста с расчетами.
        /// </summary>
        /// <param name="isVisible">Виден ли текст.</param>
        private void SetVisible(bool isVisible)
        {
            AmountLabel.Visible = isVisible;
            TotalLabel.Visible = isVisible;
            DiscountAmountLabel.Visible = isVisible;
            AmountHeaderLabel.Visible = isVisible;
            TotalHeaderLabel.Visible = isVisible;
            DiscountAmountHeaderLabel.Visible = isVisible;
            DiscountLabel.Visible = isVisible;
        }

        /// <summary>
        /// Обновляет данные корзины покупателя.
        /// </summary>
        /// <param name="cart">Коризна покупателя класса <see cref="Cart"/>.</param>
        private void UpdateCartItems(Cart cart)
        {
            var linkedItems = new List<Item>();

            foreach (var cartItem in cart.Items)
            {
                foreach (var item in Items)
                {
                    if (cartItem.Id == item.Id)
                    {
                        linkedItems.Add(item);
                    }
                }
            }

            cart.Items = linkedItems;
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
            CustomerComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Обновляет данные списка товаров в корзине <see cref="CartListBox"/>. 
        /// </summary>
        /// <param name="nextIndex">Следующий индекс товара из корзины.</param>
        private void UpdateCartListBox(int nextIndex = -1)
        {
            if (Customers.Count == 0 || CurrentCustomer < 0)
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
            UpdateAmountLabels();
        }

        /// <summary>
        /// Обновляет данные списка скидок <see cref="DiscountsCheckedListBox"/>. 
        /// </summary>
        private void UpdateDiscountsCheckedListBox()
        {
            for (var i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                DiscountsCheckedListBox.Items[i] = 
                    Customers[CurrentCustomer].Discounts[i].Info;
            }

            UpdateAmountLabels();
        }

        /// <summary>
        /// Устанавливает данные списка скидок <see cref="DiscountsCheckedListBox"/>. 
        /// </summary>
        private void SetDiscountsCheckedListBox()
        {
            if (Customers.Count == 0 || CurrentCustomer < 0)
            {
                DiscountsCheckedListBox.Items.Clear();
                DiscountsCheckedListBox.Enabled = false;
                return;
            }

            DiscountsCheckedListBox.Items.Clear();

            foreach (var discount in Customers[CurrentCustomer].Discounts)
            {
                DiscountsCheckedListBox.Items.Add(discount.Info);
            }

            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                DiscountsCheckedListBox.SetItemChecked(i, true);
            }

            AmountLabel.Text = Customers[CurrentCustomer].Cart.Amount.ToString();
            DiscountsCheckedListBox.Enabled = true;
            DiscountAmountLabel.Text = "0";
            TotalLabel.Text = AmountLabel.Text;
        }

        /// <summary>
        /// Обновляет текстовые данные.
        /// </summary>
        private void UpdateAmountLabels()
        {
            DiscountAmount = 0M;

            foreach (var item in DiscountsCheckedListBox.CheckedItems)
            {
                var index = DiscountsCheckedListBox.Items.IndexOf(item);
                DiscountAmount += Customers[CurrentCustomer].Discounts[index].Calculate(
                    Customers[CurrentCustomer].Cart.Items);
            }

            var amount = Customers[CurrentCustomer].Cart.Amount;
            AmountLabel.Text = amount.ToString();
            DiscountAmountLabel.Text = DiscountAmount.ToString();
            TotalLabel.Text = (amount - DiscountAmount).ToString();
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

            foreach (var item in Items)
            {
                if (item == Items[ItemsListBox.SelectedIndex])
                {
                    Customers[CurrentCustomer].Cart.Items.Add(item);
                }
            }

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
            SetDiscountsCheckedListBox();
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
        /// Обновляет скидки покупателя по заданому списку товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        private void UpdateCustomerDiscounts(List<Item> items)
        {
            foreach (var discount in Customers[CurrentCustomer].Discounts)
            {
                var isChecked = DiscountsCheckedListBox.CheckedItems.Contains(discount.Info);

                if (isChecked)
                {
                    discount.Apply(items);
                }

                if (discount is PointsDiscount && isChecked)
                {
                    discount.Update(null);
                }
                else
                {
                    discount.Update(items);
                }    
                
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки создания заказа.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CreateOrderButton_Click(object sender, System.EventArgs e)
        {
            if (CurrentCustomer < 0 || CartListBox.Items.Count == 0)
            {
                return;
            }

            var items = new List<Item>();
            Order order;

            foreach (var item in Customers[CurrentCustomer].Cart.Items)
            {
                items.Add((Item)item.Clone());
            }

            if (Customers[CurrentCustomer].IsPriority)
            {
                order = new PriorityOrder(
                    OrderStatus.New,
                    Customers[CurrentCustomer].Address,
                    items,
                    DiscountAmount); 
            }
            else
            {
                order = new Order(
                    OrderStatus.New,
                    Customers[CurrentCustomer].Address,
                    items,
                    DiscountAmount);
            }

            Customers[CurrentCustomer].Orders.Add(order);
            UpdateCustomerDiscounts(items);
            Customers[CurrentCustomer].Cart.Items.Clear();
            UpdateDiscountsCheckedListBox();
            UpdateCartListBox();
        }

        /// <summary>
        /// Событие при изменении выбора или состояния элемента в 
        /// <see cref="DiscountsCheckedListBox"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DiscountsCheckedListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateAmountLabels();
        }
    }
}
