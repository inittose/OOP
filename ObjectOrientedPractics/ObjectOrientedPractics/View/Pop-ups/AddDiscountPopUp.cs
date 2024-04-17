using ObjectOrientedPractices.Model;
using ObjectOrientedPractices.Model.Discounts;
using ObjectOrientedPractices.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ObjectOrientedPractices.View.Pop_ups
{
    /// <summary>
    /// Всплывающее окно, отвечающее за выбор категории товара скидки.
    /// </summary>
    public partial class AddDiscountPopUp : Form
    {
        /// <summary>
        /// Возвращает категорию товара скидки.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает покупателя.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Создает экзепляр класса <see cref="AddDiscountPopUp"/>.
        /// </summary>
        /// <param name="customer">Текущий покупатель.</param>
        public AddDiscountPopUp(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            UpdateCategoryComboBox();
        }

        /// <summary>
        /// Обновляет данные выпадающего списка категорий товара.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            var customerCategories = new List<Category>();

            foreach (var discount in Customer.Discounts)
            {
                // TODO: Сделать так: discount is PercentDiscount percentDiscount...
                // Переменная percentDiscount сразу будет нужного типа
                if (discount is PercentDiscount percentDiscount)
                {
                    customerCategories.Add(percentDiscount.Category);
                }
            }

            var dataCategories = new List<Category>();

            foreach (var category in Enum.GetValues(typeof(Category)).Cast<Category>().ToList())
            {
                if (!customerCategories.Contains(category))
                {
                    dataCategories.Add(category);
                }
            }

            CategoryComboBox.DataSource = dataCategories;
        }

        /// <summary>
        /// Событие при нажатии на кнопку <see cref="OkButton"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Category = (Category)Enum.Parse(
                typeof(Category), 
                CategoryComboBox.SelectedItem.ToString());

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Событие при нажатии на кнопку <see cref="CancelButton"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Событие при выборе другой категории товара скидки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = CategoryComboBox.SelectedIndex >= 0;
        }
    }
}
