using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ObjectOrientedPractices.Model;
using ObjectOrientedPractices.Services;

namespace ObjectOrientedPractices.View.Controls
{
    /// <summary>
    /// Отвечает за логику работы с полями ввода адреса.
    /// </summary>
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Возвращает и задает адрес доставки класса <see cref="Model.Address"/>.
        /// </summary>
        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
                UpdateTextBoxes();
            }
        }

        /// <summary>
        /// Возвращает и задает флаг, указывающий на то, активны ли текстовые поля 
        /// вкладки <see cref="AddressControl"/>.
        /// </summary>
        public bool IsTextBoxesEnabled { get; set; } = true;

        /// <summary>
        /// Возвращает словарь, который хранит валидность текстовых полей.
        /// </summary>
        public Dictionary<TextBox, bool> Validations { get; } = new Dictionary<TextBox, bool>();

        /// <summary>
        /// Возвращает сообщение о ошибке переполнения в текстовом поле ввода.
        /// </summary>
        private string LimitErrorMessage { get; } = "Field exceeds maximum number of characters.";

        /// <summary>
        /// Возвращает и задает флаг, указывающий на то, активен ли элемент управления.
        /// </summary>
        private bool IsControlEnabled => Address != null;

        /// <summary>
        /// Инициализирует компонент, создает экземпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            Address = null;
            WrongInputLabel.Text = string.Empty;

            Validations.Add(PostIndexTextBox, true);
            Validations.Add(CountryTextBox, true);
            Validations.Add(CityTextBox, true);
            Validations.Add(StreetTextBox, true);
            Validations.Add(BuildingTextBox, true);
            Validations.Add(ApartmentTextBox, true);
        }

        /// <summary>
        /// Обновляет данные текстовых полей ввода.
        /// </summary>
        private void UpdateTextBoxes()
        {
            var isTextBoxesEnabled = IsControlEnabled && IsTextBoxesEnabled;
            PostIndexTextBox.Enabled = isTextBoxesEnabled;
            CountryTextBox.Enabled = isTextBoxesEnabled;
            CityTextBox.Enabled = isTextBoxesEnabled;
            StreetTextBox.Enabled = isTextBoxesEnabled;
            BuildingTextBox.Enabled = isTextBoxesEnabled;
            ApartmentTextBox.Enabled = isTextBoxesEnabled;

            PostIndexTextBox.Text = Address?.Index.ToString() ?? string.Empty;
            CountryTextBox.Text = Address?.Country ?? string.Empty;
            CityTextBox.Text = Address?.City ?? string.Empty;
            StreetTextBox.Text = Address?.Street ?? string.Empty;
            BuildingTextBox.Text = Address?.Building ?? string.Empty;
            ApartmentTextBox.Text = Address?.Apartment ?? string.Empty;

            foreach (var key in Validations.Keys.ToList())
            {
                Validations[key] = IsControlEnabled;
            }
        }

        /// <summary>
        /// Отвечает за валидацию текстового поля ввода при его изменении.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="value">Новое значение поля ввода или длина строки.</param>
        /// <param name="limit">Предел значения.</param>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <param name="validationMethod">Делегат метода валидации.</param>
        private void TextBoxChanged(
            TextBox sender,
            int value,
            int limit,
            string errorMessage,
            Action<int, int, string> validationMethod)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                sender.Focus();
            }

            try
            {
                validationMethod(value, limit, errorMessage);
                WrongInputLabel.Text = string.Empty;
                Validations[sender] = true;
                sender.BackColor = AppColors.RightInputColor;
            }
            catch (Exception ex)
            {
                if (!(ex is ArgumentException) && !(ex is FormatException))
                {
                    throw ex;
                }

                WrongInputLabel.Text = errorMessage;
                Validations[sender] = false;
                sender.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода почтового индекса доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        // TODO: Обработчики событий дублируются. Нужно вынести дубль в отдельный метод и вызывать его из каждого обработчика
        // UPD: +
        // TODO: не исправил см. сообщение в дискорде.
        // UPD: +
        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;
            int.TryParse((sender as TextBox).Text, out value);

            TextBoxChanged(
                sender as TextBox,
                value,
                ModelConstants.IndexDigit,
                "The field must consist of 6 digits.",
                ValueValidator.AssertIntOnDigit);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода страны доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(
                sender as TextBox,
                ModelConstants.CountryLengthLimit,
                (sender as TextBox).Text.Length,
                LimitErrorMessage,
                ValueValidator.AssertIntOnUpperLimit);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода города доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(
                sender as TextBox,
                ModelConstants.CityLengthLimit,
                (sender as TextBox).Text.Length,
                LimitErrorMessage,
                ValueValidator.AssertIntOnUpperLimit);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода улицы доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(
                sender as TextBox,
                ModelConstants.StreetLengthLimit,
                (sender as TextBox).Text.Length,
                LimitErrorMessage,
                ValueValidator.AssertIntOnUpperLimit);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода номера дома доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(
                sender as TextBox,
                ModelConstants.BuildingLengthLimit,
                (sender as TextBox).Text.Length,
                LimitErrorMessage,
                ValueValidator.AssertIntOnUpperLimit);
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода номера квартиры/помещения доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(
                sender as TextBox,
                ModelConstants.ApartmentLengthLimit,
                (sender as TextBox).Text.Length,
                LimitErrorMessage,
                ValueValidator.AssertIntOnUpperLimit);
        }

        /// <summary>
        /// Отвечает за обновление свойств объекта <see cref="Address"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="propertyName">Имя свойства объекта <see cref="Address"/>.</param>
        private void TextBoxLeave(TextBox sender, string propertyName)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            var property = Address.GetType().GetProperty(propertyName);

            if (Validations[sender])
            {
                property.SetValue(Address, sender.Text);
            }

            sender.Text = property.GetValue(Address).ToString();
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода почтового индекста доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void PostIndexTextBox_Leave(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[PostIndexTextBox])
            {
                Address.Index = int.Parse(PostIndexTextBox.Text);
            }

            PostIndexTextBox.Text = Address.Index.ToString();
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода страны доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CountryTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox, nameof(Address.Country));
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода города доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CityTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox, nameof(Address.City));
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода улицы доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StreetTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox, nameof(Address.Street));
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода номера дома доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void BuildingTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox, nameof(Address.Building));
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода номера квартиры/помещения доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ApartmentTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(sender as TextBox, nameof(Address.Apartment));
        }
    }
}
