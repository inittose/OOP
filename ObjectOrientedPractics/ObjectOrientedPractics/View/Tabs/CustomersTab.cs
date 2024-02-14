using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей класса <see cref="Customer"/>
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        private Color rightInputColor = Color.White;
        private Color wrongInputColor = Color.Red;

        public CustomersTab()
        {
            InitializeComponent();
            WrongAddressLabel.Text = string.Empty;
            WrongFullNameLabel.Text = string.Empty;
        }

        /// <summary>
        /// Устанавливает корректные данные в текстовых окнах 
        /// в зависимости от индекса товара в списке.
        /// </summary>
        /// <param name="selectedIndex">Индекс товара в списке.</param>
        private void SetTextBoxes(int selectedIndex)
        {
            bool status = selectedIndex >= 0;
            AddressTextBox.Enabled = status;
            FullNameTextBox.Enabled = status;
            if (status)
            {
                IdTextBox.Text = _customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = _customers[CustomersListBox.SelectedIndex].FullName;
                AddressTextBox.Text = _customers[CustomersListBox.SelectedIndex].Address;
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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer();
            newCustomer.FullName = $"Customer{newCustomer.Id}";
            _customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedItem = newCustomer.FullName;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = CustomersListBox.SelectedIndex;
            if (removeIndex != -1)
            {
                CustomersListBox.Items.RemoveAt(removeIndex);
                _customers.RemoveAt(removeIndex);
                if (CustomersListBox.Items.Count > 0)
                {
                    if (removeIndex < CustomersListBox.Items.Count)
                    {
                        CustomersListBox.SelectedIndex = removeIndex;
                    }
                    else
                    {
                        CustomersListBox.SelectedIndex = removeIndex - 1;
                    }
                }
            }
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongFullNameLabel.Text = String.Empty;
                FullNameTextBox.BackColor = rightInputColor;
                return;
            }
            Color currentColor = wrongInputColor;
            if (FullNameTextBox.Text.Length == 0)
            {
                WrongFullNameLabel.Text = "Full name must consist of characters.";
            }
            else if (FullNameTextBox.Text.Length > 200)
            {
                WrongFullNameLabel.Text = "Full name must be no more than 200 characters.";
            }
            else
            {
                WrongFullNameLabel.Text = String.Empty;
                currentColor = rightInputColor;
            }
            FullNameTextBox.BackColor = currentColor;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongAddressLabel.Text = String.Empty;
                AddressTextBox.BackColor = rightInputColor;
                return;
            }
            Color currentColor = wrongInputColor;
            if (AddressTextBox.Text.Length > 500)
            {
                WrongAddressLabel.Text = "Address must be no more than 500 characters.";
            }
            else
            {
                WrongAddressLabel.Text = String.Empty;
                currentColor = rightInputColor;
            }
            AddressTextBox.BackColor = currentColor;
        }

        private void FullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }
            if (FullNameTextBox.BackColor == rightInputColor)
            {
                _customers[CustomersListBox.SelectedIndex].FullName = FullNameTextBox.Text;
                CustomersListBox.Items[CustomersListBox.SelectedIndex] = FullNameTextBox.Text;
            }
            else
            {
                FullNameTextBox.Text = _customers[CustomersListBox.SelectedIndex].FullName;
            }
        }

        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }
            if (AddressTextBox.BackColor == rightInputColor)
            {
                _customers[CustomersListBox.SelectedIndex].Address = AddressTextBox.Text;
                CustomersListBox.Items[CustomersListBox.SelectedIndex] = AddressTextBox.Text;
            }
            else
            {
                AddressTextBox.Text = _customers[CustomersListBox.SelectedIndex].Address;
            }
        }
    }
}
