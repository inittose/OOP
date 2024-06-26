﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractices.Model;
using ObjectOrientedPractices.Model.Discounts;
using ObjectOrientedPractices.Services;
using ObjectOrientedPractices.View.Pop_ups;

namespace ObjectOrientedPractices.View.Tabs
{
    /// <summary>
    /// Отвечает за логику работы вкладки с покупателями.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей класса <see cref="Customer"/>.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Событие при обновлении информации о покупателях <see cref="Customer"/>.
        /// </summary>
        public event EventHandler<EventArgs> CustomersChanged;

        /// <summary>
        /// Возвращает и задает список покупателей класса <see cref="Customer"/>.
        /// </summary>
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;

                if (value != null)
                {
                    UpdateCustomersListBox();
                    CustomersChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает словарь, который хранит валидность текстовых полей.
        /// </summary>
        public Dictionary<TextBox, bool> Validations { get; } = new Dictionary<TextBox, bool>();

        /// <summary>
        /// Инициализирует компонент, 
        /// убирает ошибки валидации и загружает сохраненных покупателей.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            WrongFullNameLabel.Text = string.Empty;
            Validations.Add(FullNameTextBox, true);
        }

        /// <summary>
        /// Обновляет данные в списке скидок покупателя.
        /// </summary>
        /// <param name="customer">Текущий покупатель.</param>
        private void UpdateDiscountsListBox(Customer customer)
        {
            DiscountsListBox.Items.Clear();

            foreach (var discount in customer.Discounts)
            {
                DiscountsListBox.Items.Add(discount.Info);
            }
        }

        /// <summary>
        /// Обновляет данные в списке покупателей.
        /// </summary>
        private void UpdateCustomersListBox()
        {
            CustomersListBox.Items.Clear();

            foreach (var customer in Customers)
            {
                CustomersListBox.Items.Add(customer.FullName);
            }
        }

        /// <summary>
        /// Устанавливает корректные данные в текстовых окнах 
        /// в зависимости от индекса товара в списке.
        /// </summary>
        /// <param name="selectedIndex">Индекс товара в списке.</param>
        private void SetTextBoxes(int selectedIndex)
        {
            var isSelectedIndexCorrect = selectedIndex >= 0;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;
            IsPriorityCheckBox.Enabled = isSelectedIndexCorrect;
            DiscountsListBox.Enabled = isSelectedIndexCorrect;
            AddDiscountButton.Enabled = isSelectedIndexCorrect;

            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = Customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
                AddressControl.Address = Customers[CustomersListBox.SelectedIndex].Address;
                IsPriorityCheckBox.Checked = Customers[CustomersListBox.SelectedIndex].IsPriority;
                UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);
            }
            else
            {
                FullNameTextBox.Text = string.Empty;
                IdTextBox.Text = string.Empty;
                AddressControl.Address = null;
                IsPriorityCheckBox.Checked = false;
                DiscountsListBox.Items.Clear();
            }
        }

        /// <summary>
        /// Событие при изменении выбора в списке покупателей.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(CustomersListBox.SelectedIndex);
        }

        /// <summary>
        /// Событие при нажатии кнопки добавления покупателя.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer();
            newCustomer.FullName = $"Customer{newCustomer.Id}";
            Customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedIndex = CustomersListBox.Items.Count - 1;
            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при нажатии кнопки добавления случайного покупателя.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddRandomButton_Click(object sender, EventArgs e)
        {
            var newCustomer = CustomerFactory.GetRandomCustomer();
            Customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedIndex = CustomersListBox.Items.Count - 1;
            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при нажатии кнопки удаления покупателя.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removeIndex = CustomersListBox.SelectedIndex;

            if (removeIndex < 0)
            {
                return;
            }

            IdGenerator.ReleaseId(Customers[removeIndex].Id);

            foreach (var order in Customers[removeIndex].Orders)
            {
                IdGenerator.ReleaseId(order.Id);
            }

            CustomersListBox.Items.RemoveAt(removeIndex);
            Customers.RemoveAt(removeIndex);

            if (CustomersListBox.Items.Count <= 0)
            {
                return;
            }

            if (removeIndex < CustomersListBox.Items.Count)
            {
                CustomersListBox.SelectedIndex = removeIndex;
            }
            else
            {
                CustomersListBox.SelectedIndex = removeIndex - 1;
            }

            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода имени покупателя.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongFullNameLabel.Text = string.Empty;
                FullNameTextBox.BackColor = AppColors.RightInputColor;
                return;
            }

            if ((sender as TextBox).Focused)
            {
                try
                {
                    ValueValidator.AssertStringOnLengthLimits(
                        FullNameTextBox.Text,
                        0,
                        ModelConstants.FullnameLengthLimit,
                        "FullName");

                    WrongFullNameLabel.Text = string.Empty;
                    FullNameTextBox.BackColor = AppColors.RightInputColor;
                    Validations[FullNameTextBox] = true;
                }
                catch (ArgumentException ex)
                {
                    WrongFullNameLabel.Text = ex.Message;
                    FullNameTextBox.BackColor = AppColors.WrongInputColor;
                    Validations[FullNameTextBox] = false;
                }
            }
            else
            {
                if (Validations[FullNameTextBox])
                {
                    Customers[CustomersListBox.SelectedIndex].FullName = FullNameTextBox.Text;
                    CustomersListBox.Items[CustomersListBox.SelectedIndex] = FullNameTextBox.Text;
                    CustomersChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
                    WrongFullNameLabel.Text = string.Empty;
                    FullNameTextBox.BackColor = AppColors.RightInputColor;
                    Validations[FullNameTextBox] = true;
                }
            }
        }

        /// <summary>
        /// Событие при смене выбора в <see cref="IsPriorityCheckBox"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void IsPriorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }

            Customers[CustomersListBox.SelectedIndex].IsPriority = IsPriorityCheckBox.Checked;
            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при нажатии на <see cref="AddDiscountButton"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            var addDiscountPopUp = new AddDiscountPopUp(Customers[CustomersListBox.SelectedIndex]);

            if (addDiscountPopUp.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var discount = new PercentDiscount(addDiscountPopUp.Category);
            Customers[CustomersListBox.SelectedIndex].Discounts.Add(discount);
            UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);
            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при нажатии на <see cref="RemoveDiscountButton"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveDiscountButton_Click(object sender, EventArgs e)
        {
            var removedIndex = DiscountsListBox.SelectedIndex;
            Customers[CustomersListBox.SelectedIndex].Discounts.RemoveAt(
                DiscountsListBox.SelectedIndex);
            UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);

            if (removedIndex >= DiscountsListBox.Items.Count)
            {
                DiscountsListBox.SelectedIndex = removedIndex - 1;
            }
            else
            {
                DiscountsListBox.SelectedIndex = removedIndex;
            }

            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие при смене элемента в <see cref="DiscountsListBox"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DiscountsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveDiscountButton.Enabled = DiscountsListBox.SelectedIndex > 0;
        }
    }
}