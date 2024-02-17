﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Отвечает за логику работы вкладки с товарами.
    /// </summary>
    public partial class ItemsTab : UserControl
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
        /// Список товаров класса <see cref="Item"/>.
        /// </summary>
        private List<Item> _items = Serializer.GetItems();

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

        public ItemsTab()
        {
            InitializeComponent();
            WrongCostLabel.Text = string.Empty;
            WrongNameLabel.Text = string.Empty;
            WrongDescriptionLabel.Text = string.Empty;
            for (int i = 0; i < _items.Count; i++)
            {
                ItemsListBox.Items.Add(_items[i].Name);
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
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
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
            if (removeIndex == -1)
            {
                return;
            }

            ItemsListBox.Items.RemoveAt(removeIndex);
            _items.RemoveAt(removeIndex);
            Serializer.SetItems(_items);
            if (ItemsListBox.Items.Count <= 0)
            {
                return;
            }

            if (removeIndex < ItemsListBox.Items.Count)
            {
                ItemsListBox.SelectedIndex = removeIndex;
            }
            else
            {
                ItemsListBox.SelectedIndex = removeIndex - 1;
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
            Serializer.SetItems(_items);
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongCostLabel.Text = String.Empty;
                CostTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            float getParse = 0;
            if (!float.TryParse(CostTextBox.Text, out getParse))
            {
                WrongCostLabel.Text = "Cost must be a float number.";
            }
            else if (getParse <= Item.MinimumCost)
            {
                WrongCostLabel.Text = $"Cost must be greater than {Item.MinimumCost}.";
            }
            else if (getParse > Item.MaximumCost)
            {
                WrongCostLabel.Text = $"Сost must be less than {Item.MaximumCost}.";
            }
            else
            {
                WrongCostLabel.Text = String.Empty;
                currentColor = RightInputColor;
            }
            CostTextBox.BackColor = currentColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongNameLabel.Text = String.Empty;
                NameTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            if (NameTextBox.Text.Length == 0)
            {
                WrongNameLabel.Text = "Name must consist of characters.";
            }
            else if (NameTextBox.Text.Length > Item.NameLengthLimit)
            {
                WrongNameLabel.Text = 
                    $"Name must be no more than {Item.NameLengthLimit} characters.";
            }
            else
            {
                WrongNameLabel.Text = String.Empty;
                currentColor = RightInputColor;
            }
            NameTextBox.BackColor = currentColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongDescriptionLabel.Text = String.Empty;
                DescriptionTextBox.BackColor = RightInputColor;
                return;
            }
            var currentColor = WrongInputColor;
            if (DescriptionTextBox.Text.Length > Item.InfoLengthLimit)
            {
                WrongDescriptionLabel.Text = 
                    $"Description should not exceed {Item.InfoLengthLimit} characters";
            }
            else
            {
                WrongDescriptionLabel.Text = String.Empty;
                currentColor = RightInputColor;
            }
            DescriptionTextBox.BackColor = currentColor;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (NameTextBox.BackColor == RightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
                Serializer.SetItems(_items);
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
            if (CostTextBox.BackColor == RightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
                Serializer.SetItems(_items);
            }
            CostTextBox.Text = _items[ItemsListBox.SelectedIndex].Cost.ToString();
        }

        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (DescriptionTextBox.BackColor == RightInputColor)
            {
                _items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
                Serializer.SetItems(_items);
            }
            else
            {
                DescriptionTextBox.Text = _items[ItemsListBox.SelectedIndex].Info;
            }
        }
    }
}
