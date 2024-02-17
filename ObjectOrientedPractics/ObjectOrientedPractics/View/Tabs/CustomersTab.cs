using System;
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
        /// Цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        private static readonly Color _rightInputColor = Color.White;

        /// <summary>
        /// Цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        private static readonly Color _wrongInputColor = Color.Red;

        /// <summary>
        /// Список покупателей класса <see cref="Customer"/>
        /// </summary>
        private List<Customer> _customers = Serializer.GetCustomers();

        /// <summary>
        /// Возвращает цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        private static Color RightInputColor
        {
            get => _rightInputColor;
        }

        /// <summary>
        /// Возвращает цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        private static Color WrongInputColor
        {
            get => _wrongInputColor;
        }

        /// <summary>
        /// Возвращает список покупателей <see cref="List<Customer>"/>.
        /// </summary>
        private List<Customer> Customers
        {
            get => _customers;
        }

        /// <summary>
        /// Инициализировать компонент, 
        /// убрать ошибки валидации и загрузить сохраненных покупателей.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            WrongAddressLabel.Text = string.Empty;
            WrongFullNameLabel.Text = string.Empty;
            for (int i = 0; i < Customers.Count; i++)
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
            bool isSelectedIndexCorrect = selectedIndex >= 0;
            AddressTextBox.Enabled = isSelectedIndexCorrect;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = Customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
                AddressTextBox.Text = Customers[CustomersListBox.SelectedIndex].Address;
            }
            else
            {
                FullNameTextBox.Text = String.Empty;
                AddressTextBox.Text = String.Empty;
                IdTextBox.Text = String.Empty;
            }
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(CustomersListBox.SelectedIndex);
            Serializer.SetCustomers(Customers);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer();
            newCustomer.FullName = $"Customer{newCustomer.Id}";
            Customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedIndex = CustomersListBox.Items.Count - 1;
        }

        private void AddRandomButton_Click(object sender, EventArgs e)
        {
            Customer newCustomer = CustomerFactory.GetRandomCustomer();
            Customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedIndex = CustomersListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = CustomersListBox.SelectedIndex;
            if (removeIndex == -1)
            {
                return;
            }

            CustomersListBox.Items.RemoveAt(removeIndex);
            Customers.RemoveAt(removeIndex);
            Serializer.SetCustomers(Customers);

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

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongFullNameLabel.Text = String.Empty;
                FullNameTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            if (FullNameTextBox.Text.Length == 0)
            {
                WrongFullNameLabel.Text = "Full name must consist of characters.";
            }
            else if (FullNameTextBox.Text.Length > Customer.FullNameLengthLimit)
            {
                WrongFullNameLabel.Text = 
                    $"Full name must be no more than {Customer.FullNameLengthLimit} characters.";
            }
            else
            {
                WrongFullNameLabel.Text = String.Empty;
                currentColor = RightInputColor;
            }
            FullNameTextBox.BackColor = currentColor;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongAddressLabel.Text = String.Empty;
                AddressTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            if (AddressTextBox.Text.Length > Customer.AddressLengthLimit)
            {
                WrongAddressLabel.Text = 
                    $"Address must be no more than {Customer.AddressLengthLimit} characters.";
            }
            else
            {
                WrongAddressLabel.Text = String.Empty;
                currentColor = RightInputColor;
            }
            AddressTextBox.BackColor = currentColor;
        }

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
                Serializer.SetCustomers(Customers);
            }
            else
            {
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
            }
        }

        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }
            if (AddressTextBox.BackColor == RightInputColor)
            {
                Customers[CustomersListBox.SelectedIndex].Address = AddressTextBox.Text;
                CustomersListBox.Items[CustomersListBox.SelectedIndex] = AddressTextBox.Text;
                Serializer.SetCustomers(Customers);
            }
            else
            {
                AddressTextBox.Text = Customers[CustomersListBox.SelectedIndex].Address;
            }
        }
    }
}
