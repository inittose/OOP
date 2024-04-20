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
        /// Событие при изменении текста в текстовом поле ввода почтового индекса доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        // TODO: Обработчики событий дублируются. Нужно вынести дубль в отдельный метод и вызывать его из каждого обработчика
        // UPD: +
        // TODO: не исправил см. сообщение в дискорде.
        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertIntOnDigit(
                    int.Parse(PostIndexTextBox.Text),
                    ModelConstants.IndexDigit,
                    nameof(PostIndexTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[PostIndexTextBox] = true;
                PostIndexTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (Exception ex)
            {
                if (!(ex is ArgumentException) && !(ex is FormatException))
                {
                    throw ex;
                }

                WrongInputLabel.Text = "The field must consist of 6 digits.";
                Validations[PostIndexTextBox] = false;
                PostIndexTextBox.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода страны доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertStringOnLength(
                    CountryTextBox.Text, 
                    ModelConstants.CountryLengthLimit, 
                    nameof(CountryTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[CountryTextBox] = true;
                CountryTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (ArgumentException)
            {
                WrongInputLabel.Text = LimitErrorMessage;
                Validations[CountryTextBox] = false;
                CountryTextBox.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода города доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertStringOnLength(
                    CityTextBox.Text,
                    ModelConstants.CityLengthLimit,
                    nameof(CityTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[CityTextBox] = true;
                CityTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (ArgumentException)
            {
                WrongInputLabel.Text = LimitErrorMessage;
                Validations[CityTextBox] = false;
                CityTextBox.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода улицы доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertStringOnLength(
                    StreetTextBox.Text,
                    ModelConstants.StreetLengthLimit,
                    nameof(StreetTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[StreetTextBox] = true;
                StreetTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (ArgumentException)
            {
                WrongInputLabel.Text = LimitErrorMessage;
                Validations[StreetTextBox] = false;
                StreetTextBox.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода номера дома доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertStringOnLength(
                    BuildingTextBox.Text,
                    ModelConstants.BuildingLengthLimit,
                    nameof(BuildingTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[BuildingTextBox] = true;
                BuildingTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (ArgumentException)
            {
                WrongInputLabel.Text = LimitErrorMessage;
                Validations[BuildingTextBox] = false;
                BuildingTextBox.BackColor = AppColors.WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода номера квартиры/помещения доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (ActiveControl != null)
            {
                (sender as TextBox).Focus();
            }

            try
            {
                ValueValidator.AssertStringOnLength(
                    ApartmentTextBox.Text,
                    ModelConstants.ApartmentLengthLimit,
                    nameof(ApartmentTextBox.Text));

                WrongInputLabel.Text = string.Empty;
                Validations[ApartmentTextBox] = true;
                ApartmentTextBox.BackColor = AppColors.RightInputColor;
            }
            catch (ArgumentException)
            {
                WrongInputLabel.Text = LimitErrorMessage;
                Validations[ApartmentTextBox] = false;
                ApartmentTextBox.BackColor = AppColors.WrongInputColor;
            }
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
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[CountryTextBox])
            {
                Address.Country = CountryTextBox.Text;
            }

            CountryTextBox.Text = Address.Country;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода города доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CityTextBox_Leave(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[CityTextBox])
            {
                Address.City = CityTextBox.Text;
            }

            CityTextBox.Text = Address.City;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода улицы доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StreetTextBox_Leave(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[StreetTextBox])
            {
                Address.Street = StreetTextBox.Text;
            }

            StreetTextBox.Text = Address.Street;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода номера дома доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void BuildingTextBox_Leave(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[BuildingTextBox])
            {
                Address.Building = BuildingTextBox.Text;
            }

            BuildingTextBox.Text = Address.Building;
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода номера квартиры/помещения доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ApartmentTextBox_Leave(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (Validations[ApartmentTextBox])
            {
                Address.Apartment = ApartmentTextBox.Text;
            }

            ApartmentTextBox.Text = Address.Apartment;
        }
    }
}
