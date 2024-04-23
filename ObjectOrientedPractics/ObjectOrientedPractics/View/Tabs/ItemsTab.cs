using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractices.Model;
using ObjectOrientedPractices.Model.Enums;
using ObjectOrientedPractices.Services;

namespace ObjectOrientedPractices.View.Tabs
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
        /// Событие при обновлении информации о товарах <see cref="Item"/>.
        /// </summary>
        public event EventHandler<EventArgs> ItemsChanged;

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
                    ItemsChanged?.Invoke(this, EventArgs.Empty);
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
        /// Возвращает словарь, который хранит валидность текстовых полей.
        /// </summary>
        public Dictionary<TextBox, bool> Validations { get; } = new Dictionary<TextBox, bool>();

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
            Validations.Add(CostTextBox, true);
            Validations.Add(NameTextBox, true);
            Validations.Add(DescriptionTextBox, true);
        }

        /// <summary>
        /// Обновить список товаров, который будет выведен на экран.
        /// </summary>
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
            ItemsChanged?.Invoke(this, EventArgs.Empty);
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
            ItemsChanged?.Invoke(this, EventArgs.Empty);
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
            ItemsChanged?.Invoke(this, EventArgs.Empty);
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
        /// Отвечает за валидацию текстового поля ввода при его изменении.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="minimum">Минимальное значение.</param>
        /// <param name="maximum">Максимальное значения.</param>
        /// <param name="validationMethod">Делегат метода валидации.</param>
        private void TextBoxChange(
            TextBox sender,
            int minimum,
            int maximum,
            string propertyName,
            Action<string, int, int, string> validationMethod)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongCostLabel.Text = string.Empty;
                CostTextBox.BackColor = AppColors.RightInputColor;
                return;
            }

            try
            {
                validationMethod(
                    sender.Text,
                    minimum,
                    maximum,
                    propertyName);

                WrongCostLabel.Text = string.Empty;
                sender.BackColor = AppColors.RightInputColor;
                Validations[sender] = true;
            }
            catch (ArgumentException ex)
            {
                WrongCostLabel.Text = ex.Message;
                sender.BackColor = AppColors.WrongInputColor;
                Validations[sender] = false;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода цены товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChange(
                sender as TextBox,
                (int)ModelConstants.MinimumCost,
                (int)ModelConstants.MaximumCost,
                "Cost",
                ValueValidator.AssertStringOnDecimalLimits);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода наименования товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChange(
                sender as TextBox,
                0,
                ModelConstants.NameLengthLimit,
                "Name",
                ValueValidator.AssertStringOnLengthLimits);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода описания товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChange(
                sender as TextBox,
                -1,
                ModelConstants.InfoLengthLimit,
                "Description",
                ValueValidator.AssertStringOnLengthLimits);
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
            ItemsChanged?.Invoke(this, EventArgs.Empty);
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
                FilterCompare = (item) => item.Name.Contains(FindTextBox.Text);
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
            switch (OrderByComboBox.SelectedIndex)
            {
                case 0:
                {
                    SortCompare = (firstItem, secondItem) =>
                        firstItem.Name.CompareTo(secondItem.Name) < 0;

                    break;
                }

                case 1:
                {
                    SortCompare = (firstItem, secondItem) =>
                        firstItem.Cost.CompareTo(secondItem.Cost) < 0;

                    break;
                }

                case 2:
                {
                    SortCompare = (firstItem, secondItem) =>
                        firstItem.Cost.CompareTo(secondItem.Cost) > 0;

                    break;
                }
            }

            UpdateDisplayedItems();
        }

        /// <summary>
        /// Отвечает за обновление свойств объекта <see cref="Item"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="propertyName">Имя свойства объекта <see cref="Address"/>.</param>
        private void TextBoxLeave(TextBox sender, string value, string propertyName)
        {
            var selectedItem = ItemsListBox.SelectedItem as Item;
            var property = selectedItem.GetType().GetProperty(propertyName);

            if (Validations[sender])
            {
                property.SetValue(selectedItem, value);
                ItemsChanged?.Invoke(this, EventArgs.Empty);
            }

            sender.Text = property.GetValue(selectedItem).ToString();
            UpdateDisplayedItems();
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода цены товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CostTextBox_Leave(object sender, EventArgs e)
        {
            var selectedItem = ItemsListBox.SelectedItem as Item;

            if (Validations[CostTextBox])
            {
                selectedItem.Cost = decimal.Parse(CostTextBox.Text);
                ItemsChanged?.Invoke(this, EventArgs.Empty);
            }

            CostTextBox.Text = selectedItem.Cost.ToString();
            UpdateDisplayedItems();
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода названия товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox,
                (sender as TextBox).Text,
                "Name");
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода описания товара.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox,
                (sender as TextBox).Text,
                "Info");
        }
    }
}
