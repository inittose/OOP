using System;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.View.Controls
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
        /// Возвращает сообщение о ошибке в текстовом поле ввода.
        /// </summary>
        private string LimitErrorMessage { get; } = "Поле превышает макс. кол-во символов.";

        /// <summary>
        /// Возвращает и задает флаг, указывающий на то, активен ли элемент управления.
        /// </summary>
        private bool IsControlEnabled { get; set; }

        /// <summary>
        /// Возвращает и задает флаг, указывающий на то, активны ли текстовые поля 
        /// вкладки <see cref="AddressControl"/>.
        /// </summary>
        public bool IsTextBoxesEnabled { get; set; } = true;

        /// <summary>
        /// Инициализирует компонент, создает экземпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            Address = null;
            WrongInputLabel.Text = string.Empty;
        }

        /// <summary>
        /// Обновляет данные текстовых полей ввода.
        /// </summary>
        private void UpdateTextBoxes()
        {
            IsControlEnabled = Address != null;
            var isTextBoxesEnabled = IsControlEnabled && IsTextBoxesEnabled;
            PostIndexTextBox.Enabled = isTextBoxesEnabled;
            CountryTextBox.Enabled = isTextBoxesEnabled;
            CityTextBox.Enabled = isTextBoxesEnabled;
            StreetTextBox.Enabled = isTextBoxesEnabled;
            BuildingTextBox.Enabled = isTextBoxesEnabled;
            ApartmentTextBox.Enabled = isTextBoxesEnabled;

            if (IsControlEnabled)
            {
                PostIndexTextBox.Text = Address.Index.ToString();
                CountryTextBox.Text = Address.Country;
                CityTextBox.Text = Address.City;
                StreetTextBox.Text = Address.Street;
                BuildingTextBox.Text = Address.Building;
                ApartmentTextBox.Text = Address.Apartment;
            }
            else
            {
                PostIndexTextBox.Text = string.Empty;
                CountryTextBox.Text = string.Empty;
                CityTextBox.Text = string.Empty;
                StreetTextBox.Text = string.Empty;
                BuildingTextBox.Text = string.Empty;
                ApartmentTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Событие при изменении текста в текстовом поле ввода почтового индекса доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsControlEnabled)
            {
                return;
            }

            if (
                PostIndexTextBox.Text.Length == Address.IndexDigit && 
                int.TryParse(PostIndexTextBox.Text, out var temp))
            {
                WrongInputLabel.Text = string.Empty;
                PostIndexTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = "Поле должно состоять из 6 цифр.";
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

            if (CountryTextBox.Text.Length <= Address.CountryLengthLimit)
            {
                WrongInputLabel.Text = string.Empty;
                CountryTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = LimitErrorMessage;
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

            if (CityTextBox.Text.Length <= Address.CityLengthLimit)
            {
                WrongInputLabel.Text = string.Empty;
                CityTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = LimitErrorMessage;
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

            if (StreetTextBox.Text.Length <= Address.StreetLengthLimit)
            {
                WrongInputLabel.Text = string.Empty;
                StreetTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = LimitErrorMessage;
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

            if (BuildingTextBox.Text.Length <= Address.BuildingLengthLimit)
            {
                WrongInputLabel.Text = string.Empty;
                BuildingTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = LimitErrorMessage;
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

            if (ApartmentTextBox.Text.Length <= Address.ApartmentLengthLimit)
            {
                WrongInputLabel.Text = string.Empty;
                ApartmentTextBox.BackColor = AppColors.RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = LimitErrorMessage;
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

            if (PostIndexTextBox.BackColor == AppColors.RightInputColor)
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

            if (CountryTextBox.BackColor == AppColors.RightInputColor)
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

            if (CityTextBox.BackColor == AppColors.RightInputColor)
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

            if (StreetTextBox.BackColor == AppColors.RightInputColor)
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

            if (BuildingTextBox.BackColor == AppColors.RightInputColor)
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

            if (ApartmentTextBox.BackColor == AppColors.RightInputColor)
            {
                Address.Apartment = ApartmentTextBox.Text;
            }

            ApartmentTextBox.Text = Address.Apartment;
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода номера почтового индекса доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void PostIndexTextBox_Enter(object sender, EventArgs e)
        {
            PostIndexTextBox.Focus();
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода страны доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CountryTextBox_Enter(object sender, EventArgs e)
        {
            CountryTextBox.Focus();
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода города доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void CityTextBox_Enter(object sender, EventArgs e)
        {
            CityTextBox.Focus();
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода улицы доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void StreetTextBox_Enter(object sender, EventArgs e)
        {
            StreetTextBox.Focus();
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода номера дома доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void BuildingTextBox_Enter(object sender, EventArgs e)
        {
            BuildingTextBox.Focus();
        }

        /// <summary>
        /// Событие при входе в текстового поля ввода номера квартиры/помещения доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ApartmentTextBox_Enter(object sender, EventArgs e)
        {
            ApartmentTextBox.Focus();
        }
    }
}
