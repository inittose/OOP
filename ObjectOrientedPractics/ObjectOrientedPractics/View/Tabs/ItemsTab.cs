using ObjectOrientedPractics.Model;
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
        List<Item> _items = new List<Item>();

        public ItemsTab()
        {
            InitializeComponent();
        }

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
            newItem.Name = $"New item{newItem.Id}";
            _items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedItem = newItem.Name;
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
                CostTextBox.BackColor = Color.White;
                NameTextBox.BackColor = Color.White;
                DescriptionTextBox.BackColor = Color.White;
            }
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(ItemsListBox.SelectedIndex);
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            Color currentColor;
            try
            {
                _items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
                currentColor = Color.White;
            }
            catch
            {
                currentColor = Color.Red;
            }
            CostTextBox.BackColor = currentColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            Color currentColor;
            try
            {
                _items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
                NameTextBox.Focus();
                NameTextBox.Select(NameTextBox.Text.Length, 0);
                currentColor = Color.White;
            }
            catch
            {
                currentColor = Color.Red;
            }
            NameTextBox.BackColor = currentColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            Color currentColor;
            try
            {
                _items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
                currentColor = Color.White;
            }
            catch
            {
                currentColor = Color.Red;
            }
            DescriptionTextBox.BackColor = currentColor;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                //ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
            }
            catch
            {

            }
        }
    }
}
