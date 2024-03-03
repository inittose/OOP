using System;
using System.Collections.Generic;
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
        /// Список товаров класса <see cref="Item"/>.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Возвращает и задает список товаров класса <see cref="Item"/>.
        /// </summary>
        public List<Item> Items 
        { 
            get => _items; 
            set
            {
                _items = value;
                if (value != null)
                {
                    UpdateItemsListBox();
                }
            }
        }

        /// <summary>
        /// Инициализирует компонент, 
        /// убирает ошибки валидации и загружает сохраненные товары.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
            CategoryComboBox.SelectedIndex = -1;
            WrongCostLabel.Text = string.Empty;
            WrongNameLabel.Text = string.Empty;
            WrongDescriptionLabel.Text = string.Empty;
            
        }

        /// <summary>
        /// Обновляет данные в списке товаров.
        /// </summary>
        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in Items) 
            {
                ItemsListBox.Items.Add(item.Name);
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
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            CategoryComboBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
            {
                NameTextBox.Text = Items[ItemsListBox.SelectedIndex].Name;
                CostTextBox.Text = Items[ItemsListBox.SelectedIndex].Cost.ToString();
                IdTextBox.Text = Items[ItemsListBox.SelectedIndex].Id.ToString();
                DescriptionTextBox.Text = Items[ItemsListBox.SelectedIndex].Info;
                CategoryComboBox.SelectedIndex = (int)Items[ItemsListBox.SelectedIndex].Category;
            }
            else
            {
                NameTextBox.Text = string.Empty;
                CostTextBox.Text = string.Empty;
                IdTextBox.Text = string.Empty;
                DescriptionTextBox.Text = string.Empty;
                CategoryComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки добавления товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var newItem = new Item();
            newItem.Name = $"Item{newItem.Id}";
            Items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
        }

        /// <summary>
        /// Событие при нажатии кнопки удаления товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removeIndex = ItemsListBox.SelectedIndex;
            if (removeIndex == -1)
            {
                return;
            }

            IdGenerator.ReleaseId(Items[removeIndex].Id);
            ItemsListBox.Items.RemoveAt(removeIndex);
            Items.RemoveAt(removeIndex);
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

        /// <summary>
        /// Событие при нажатии кнопки добавления случайного товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddRandomButton_Click(object sender, EventArgs e)
        {
            var newItem = ItemFactory.GetRandomItem();
            Items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
        }

        /// <summary>
        /// Событие при изменении выбора в списке товаров.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(ItemsListBox.SelectedIndex);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода цены товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongCostLabel.Text = string.Empty;
                CostTextBox.BackColor = AppColors.RightInputColor;
                return;
            }
            var currentColor = AppColors.WrongInputColor;
            var getParse = 0f;
            if (!float.TryParse(CostTextBox.Text, out getParse))
            {
                WrongCostLabel.Text = "Cost must be a float number.";
            }
            else if (getParse <= Item.MINIMUM_COST)
            {
                WrongCostLabel.Text = $"Cost must be greater than {Item.MINIMUM_COST}.";
            }
            else if (getParse > Item.MAXIMUM_COST)
            {
                WrongCostLabel.Text = $"Сost must be less than {Item.MAXIMUM_COST}.";
            }
            else
            {
                WrongCostLabel.Text = string.Empty;
                currentColor = AppColors.RightInputColor;
            }
            CostTextBox.BackColor = currentColor;
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода наименования товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongNameLabel.Text = string.Empty;
                NameTextBox.BackColor = AppColors.RightInputColor;
                return;
            }
            var currentColor = AppColors.WrongInputColor;
            if (NameTextBox.Text.Length == 0)
            {
                WrongNameLabel.Text = "Name must consist of characters.";
            }
            else if (NameTextBox.Text.Length > Item.NAME_LENGTH_LIMIT)
            {
                WrongNameLabel.Text = 
                    $"Name must be no more than {Item.NAME_LENGTH_LIMIT} characters.";
            }
            else
            {
                WrongNameLabel.Text = string.Empty;
                currentColor = AppColors.RightInputColor;
            }
            NameTextBox.BackColor = currentColor;
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода описания товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongDescriptionLabel.Text = string.Empty;
                DescriptionTextBox.BackColor = AppColors.RightInputColor;
                return;
            }
            var currentColor = AppColors.WrongInputColor;
            if (DescriptionTextBox.Text.Length > Item.INFO_LENGTH_LIMIT)
            {
                WrongDescriptionLabel.Text = 
                    $"Description should not exceed {Item.INFO_LENGTH_LIMIT} characters";
            }
            else
            {
                WrongDescriptionLabel.Text = string.Empty;
                currentColor = AppColors.RightInputColor;
            }
            DescriptionTextBox.BackColor = currentColor;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода наименования товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (NameTextBox.BackColor == AppColors.RightInputColor)
            {
                Items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
            }
            else
            {
                NameTextBox.Text = Items[ItemsListBox.SelectedIndex].Name;
            }
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода цены товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CostTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (CostTextBox.BackColor == AppColors.RightInputColor)
            {
                Items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
            }
            CostTextBox.Text = Items[ItemsListBox.SelectedIndex].Cost.ToString();
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода описания товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            if (DescriptionTextBox.BackColor == AppColors.RightInputColor)
            {
                Items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
            }
            else
            {
                DescriptionTextBox.Text = Items[ItemsListBox.SelectedIndex].Info;
            }
        }

        /// <summary>
        /// Событие при изменении выбора в списке категорий товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }
            Items[ItemsListBox.SelectedIndex].Category = (Category)CategoryComboBox.SelectedIndex;
        }
    }
}
