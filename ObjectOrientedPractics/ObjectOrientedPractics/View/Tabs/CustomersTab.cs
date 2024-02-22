﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.View.Tabs
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
                }
            }
        }

        /// <summary>
        /// Цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        private Color RightInputColor { get; } = Color.White;

        /// <summary>
        /// Цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        private Color WrongInputColor { get; } = Color.Red;

        /// <summary>
        /// Инициализировать компонент, 
        /// убрать ошибки валидации и загрузить сохраненных покупателей.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            WrongFullNameLabel.Text = string.Empty;
        }

        /// <summary>
        /// Обновляет данные в списке покупателей.
        /// </summary>
        private void UpdateCustomersListBox()
        {
            CustomersListBox.Items.Clear();
            for (var i = 0; i < Customers.Count; i++)
            {
                CustomersListBox.Items.Add(Customers[i].FullName);
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
            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = Customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
                AddressControl.Address = Customers[CustomersListBox.SelectedIndex].Address;
            }
            else
            {
                FullNameTextBox.Text = string.Empty;
                IdTextBox.Text = string.Empty;
                AddressControl.Address = null;
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
                FullNameTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            if (FullNameTextBox.Text.Length == 0)
            {
                WrongFullNameLabel.Text = "Full name must consist of characters.";
            }
            else if (FullNameTextBox.Text.Length > Customer.FULLNAME_LENGTH_LIMIT)
            {
                WrongFullNameLabel.Text = 
                    $"Full name must be no more than {Customer.FULLNAME_LENGTH_LIMIT} characters.";
            }
            else
            {
                WrongFullNameLabel.Text = string.Empty;
                currentColor = RightInputColor;
            }
            FullNameTextBox.BackColor = currentColor;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода имени покупателя.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void FullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }
            if (FullNameTextBox.BackColor == RightInputColor)
            {
                Customers[CustomersListBox.SelectedIndex].FullName = FullNameTextBox.Text;
                CustomersListBox.Items[CustomersListBox.SelectedIndex] = FullNameTextBox.Text;
            }
            else
            {
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
            }
        }
    }
}
