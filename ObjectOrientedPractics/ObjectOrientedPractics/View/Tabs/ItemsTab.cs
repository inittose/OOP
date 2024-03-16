using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
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
        /// Список товаров класса <see cref="Item"/>, выведенный на экран.
        /// </summary>
        private List<Item> _displayedItems;

        /// <summary>
        /// Возвращает и задает список товаров класса <see cref="Item"/>.
        /// </summary>
        public List<Item> Items 
        { 
            get => _items; 
            set
            {
                _items = value;

                if (Items != null)
                {
                    UpdateDisplayedItems();
                    OrderByComboBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает список товаров класса <see cref="Item"/>, выведенный на экран.
        /// </summary>
        public List<Item> DisplayedItems
        {
            get => _displayedItems;
            set
            {
                _displayedItems = value;

                if (DisplayedItems != null)
                {
                    UpdateItemsListBox();
                }
            }
        }

        /// <summary>
        /// Возвращает и задает делигат критерия сортировки.
        /// </summary>
        private DataTools.CompareProperties SortCompare { get; set; }

        /// <summary>
        /// Возвращает и задает делигат критерия фильтрации.
        /// </summary>
        private Predicate<Item> FilterCompare { get; set; }

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
            ItemsListBox.DisplayMember = "Name";
        }

        /// <summary>
        /// Обновить список товаров, который будет выведен на экран.
        /// </summary>
        /// <param name="compare">Метод критерия проверки товаров.</param>
        private void UpdateDisplayedItems()
        {
            var displayedItems = Items;

            if (FilterCompare != null)
            {
                displayedItems = DataTools.FilterItems(displayedItems, FilterCompare);
            }

            if (SortCompare != null)
            {
                displayedItems = DataTools.SortItems(displayedItems, SortCompare);
            }

            DisplayedItems = displayedItems;
            SetTextBoxes();
        }
            

        /// <summary>
        /// Обновляет данные в списке товаров.
        /// </summary>
        private void UpdateItemsListBox()
        {
            var selectedItem = ItemsListBox.SelectedItem;
            ItemsListBox.Items.Clear();

            foreach (var item in DisplayedItems) 
            {
                ItemsListBox.Items.Add(item);
            }

            ItemsListBox.SelectedItem = selectedItem;
        }

        /// <summary>
        /// Устанавливает корректные данные в текстовых окнах 
        /// в зависимости от индекса товара в списке.
        /// </summary>
        /// <param name="selectedIndex">Индекс товара в списке.</param>
        private void SetTextBoxes()
        {
            var isSelectedIndexCorrect = ItemsListBox.SelectedItem != null;
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            CategoryComboBox.Enabled = isSelectedIndexCorrect;

            if (isSelectedIndexCorrect)
            {
                var selectedItem = ItemsListBox.SelectedItem as Item;
                NameTextBox.Text = selectedItem.Name;
                CostTextBox.Text = selectedItem.Cost.ToString();
                IdTextBox.Text = selectedItem.Id.ToString();
                DescriptionTextBox.Text = selectedItem.Info;
                CategoryComboBox.SelectedIndex = (int)selectedItem.Category;
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
            ItemsListBox.Items.Add(newItem);
            UpdateDisplayedItems();
            ItemsListBox.SelectedItem = newItem;
        }

        /// <summary>
        /// Событие при нажатии кнопки удаления товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removingItem = ItemsListBox.SelectedItem as Item;

            if (removingItem == null)
            {
                return;
            }

            var nextIndex =
                ItemsListBox.Items.IndexOf(removingItem) < ItemsListBox.Items.Count - 1 ? 
                ItemsListBox.Items.IndexOf(removingItem):
                ItemsListBox.Items.IndexOf(removingItem) - 1;

            IdGenerator.ReleaseId(removingItem.Id);
            ItemsListBox.Items.Remove(removingItem);
            Items.Remove(removingItem);
            ItemsListBox.SelectedIndex = nextIndex;
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
            ItemsListBox.Items.Add(newItem);
            UpdateDisplayedItems();
            ItemsListBox.SelectedItem = newItem;
        }

        /// <summary>
        /// Событие при изменении выбора в списке товаров.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes();
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
            if (ItemsListBox.SelectedItem == null)
            {
                return;
            }

            var selectedItem = ItemsListBox.SelectedItem as Item;

            if (NameTextBox.BackColor == AppColors.RightInputColor)
            {
                selectedItem.Name = NameTextBox.Text;
            }
            else
            {
                NameTextBox.Text = selectedItem.Name;
            }

            UpdateDisplayedItems();
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

            var selectedItem = ItemsListBox.SelectedItem as Item;

            if (CostTextBox.BackColor == AppColors.RightInputColor)
            {
                selectedItem.Cost = float.Parse(CostTextBox.Text);
            }

            CostTextBox.Text = selectedItem.Cost.ToString();
            UpdateDisplayedItems();
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

            var selectedItem = ItemsListBox.SelectedItem as Item;

            if (DescriptionTextBox.BackColor == AppColors.RightInputColor)
            {
                selectedItem.Info = DescriptionTextBox.Text;
            }
            else
            {
                DescriptionTextBox.Text = selectedItem.Info;
            }
        }

        /// <summary>
        /// Событие при изменении выбора в списке категорий товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                return;
            }

            var selectedItem = ItemsListBox.SelectedItem as Item;
            selectedItem.Category = (Category)CategoryComboBox.SelectedIndex;
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле поиска товаров.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text.Length == 0)
            {
                FilterCompare = null;
            }
            else
            {
                FilterCompare = (item) => { return item.Name.Contains(FindTextBox.Text); };
            }

            UpdateDisplayedItems();
        }

        /// <summary>
        /// Событие при изменении выбора в списке сортировок товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void OrderByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(OrderByComboBox.SelectedIndex)
            {
                case 0:
                    SortCompare = (firstItem, secondItem) =>
                    {
                        return firstItem.Name.CompareTo(secondItem.Name) < 0;
                    };

                    break;
                case 1:
                    SortCompare = (firstItem, secondItem) =>
                    {
                        return firstItem.Cost.CompareTo(secondItem.Cost) < 0;
                    };

                    break;
                case 2:
                    SortCompare = (firstItem, secondItem) =>
                    {
                        return firstItem.Cost.CompareTo(secondItem.Cost) > 0;
                    };

                    break;
            }

            var selectedItem = ItemsListBox.SelectedItem;
            UpdateDisplayedItems();
        }
    }
}
