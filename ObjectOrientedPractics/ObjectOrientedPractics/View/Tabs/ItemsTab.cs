using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Список товаров класса <see cref="Item"/>.
        /// </summary>
        private List<Item> _items = new List<Item>();

        private Color rightInputColor = Color.White;
        private Color wrongInputColor = Color.Red;

        public ItemsTab()
        {
            InitializeComponent();
            WrongCostLabel.Text = string.Empty;
            WrongNameLabel.Text = string.Empty;
            WrongDescriptionLabel.Text = string.Empty;
        }

        /// <summary>
        /// Устанавливает корректные данные в текстовых окнах 
        /// в зависимости от индекса товара в списке.
        /// </summary>
        /// <param name="selectedIndex">Индекс товара в списке.</param>
        private void SetTextBoxes(int selectedIndex)
        {
            bool status = selectedIndex >= 0;
            CostTextBox.Enabled = status;
            NameTextBox.Enabled = status;
            DescriptionTextBox.Enabled = status;
            if (status)
            {
                NameTextBox.Text = _items[ItemsListBox.SelectedIndex].Name;
                CostTextBox.Text = _items[ItemsListBox.SelectedIndex].Cost.ToString();
                IdTextBox.Text = _items[ItemsListBox.SelectedIndex].Id.ToString();
                DescriptionTextBox.Text = _items[ItemsListBox.SelectedIndex].Info;
            }
            else
            {
                NameTextBox.Text = String.Empty;
                CostTextBox.Text = String.Empty;
                IdTextBox.Text = String.Empty;
                DescriptionTextBox.Text = String.Empty;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();
            newItem.Name = $"Item{newItem.Id}";
            _items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = ItemsListBox.SelectedIndex;
            if (removeIndex != -1)
            {
                ItemsListBox.Items.RemoveAt(removeIndex);
                _items.RemoveAt(removeIndex);
                if (ItemsListBox.Items.Count > 0)
                {
                    if (removeIndex < ItemsListBox.Items.Count)
                    {
                        ItemsListBox.SelectedIndex = removeIndex;
                    }
                    else
                    {
                        ItemsListBox.SelectedIndex = removeIndex - 1;
                    }
                }
            }
        }
        private void AddRandomButton_Click(object sender, EventArgs e)
        {
            Item newItem = ItemFactory.GetRandomItem();
            _items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(ItemsListBox.SelectedIndex);
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongCostLabel.Text = String.Empty;
                CostTextBox.BackColor = rightInputColor;
                return;
            }
            Color currentColor = wrongInputColor;
            float getParse = 0;
            if (!float.TryParse(CostTextBox.Text, out getParse))
            {
                WrongCostLabel.Text = "Cost must be a float number.";
            }
            else if (getParse <= 0)
            {
                WrongCostLabel.Text = "Cost must be greater than 0.";
            }
            else if (getParse > 100000)
            {
                WrongCostLabel.Text = "Сost must be less than 100 000.";
            }
            else
            {
                WrongCostLabel.Text = String.Empty;
                currentColor = rightInputColor;
            }
            CostTextBox.BackColor = currentColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongNameLabel.Text = String.Empty;
                NameTextBox.BackColor = rightInputColor;
                return;
            }
            Color currentColor = wrongInputColor;
            if (NameTextBox.Text.Length == 0)
            {
                WrongNameLabel.Text = "Name must consist of characters.";
            }
            else if (NameTextBox.Text.Length > 200)
            {
                WrongNameLabel.Text = "Name must be no more than 200 characters.";
            }
            else
            {
                WrongNameLabel.Text = String.Empty;
                currentColor = rightInputColor;
            }
            NameTextBox.BackColor = currentColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongDescriptionLabel.Text = String.Empty;
                DescriptionTextBox.BackColor = rightInputColor;
                return;
            }
            Color currentColor = wrongInputColor;
            if (DescriptionTextBox.Text.Length > 1000)
            {
                WrongDescriptionLabel.Text = "Description should not exceed 1000 characters";
            }
            else
            {
                WrongDescriptionLabel.Text = String.Empty;
                currentColor = rightInputColor;
            }
            DescriptionTextBox.BackColor = currentColor;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (NameTextBox.BackColor == rightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
            }
            else
            {
                NameTextBox.Text = _items[ItemsListBox.SelectedIndex].Name;
            }
        }

        private void CostTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (CostTextBox.BackColor == rightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
            }
            CostTextBox.Text = _items[ItemsListBox.SelectedIndex].Cost.ToString();
        }

        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (DescriptionTextBox.BackColor == rightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
            }
            else
            {
                DescriptionTextBox.Text = _items[ItemsListBox.SelectedIndex].Info;
            }
        }
    }
}
