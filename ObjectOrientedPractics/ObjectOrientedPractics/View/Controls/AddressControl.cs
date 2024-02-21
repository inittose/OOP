using System;
using System.Drawing;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View.Controls
{
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
        /// Цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        private Color RightInputColor { get; } = Color.White;

        /// <summary>
        /// Цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        private Color WrongInputColor { get; } = Color.Red;

        private string ErrorMessage { get; } = "Поле превышает макс. кол-во символов.";

        /// <summary>
        /// Флаг, указывающий на то, активен ли элемент управления.
        /// </summary>
        private bool IsControlEnabled { get; set; }

        /// <summary>
        /// Инициализирует компонент, создает экзпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            Address = null;
            WrongInputLabel.Text = string.Empty;
        }

        /// <summary>
        /// Обновить данные текстовых полей ввода.
        /// </summary>
        private void UpdateTextBoxes()
        {
            IsControlEnabled = Address != null;
            PostIndexTextBox.Enabled = IsControlEnabled;
            CountryTextBox.Enabled = IsControlEnabled;
            CityTextBox.Enabled = IsControlEnabled;
            StreetTextBox.Enabled = IsControlEnabled;
            BuildingTextBox.Enabled = IsControlEnabled;
            ApartmentTextBox.Enabled = IsControlEnabled;

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
            if (PostIndexTextBox.Text.Length == Address.INDEX_DIGIT && 
                                int.TryParse(PostIndexTextBox.Text, out var temp))
            {
                WrongInputLabel.Text = string.Empty;
                PostIndexTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = "Поле должно состоять из 6 цифр.";
                PostIndexTextBox.BackColor = WrongInputColor;
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
            if (CountryTextBox.Text.Length <= Address.COUNTRY_LENGTH_LIMIT)
            {
                WrongInputLabel.Text = string.Empty;
                CountryTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = ErrorMessage;
                CountryTextBox.BackColor = WrongInputColor;
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
            if (CityTextBox.Text.Length <= Address.CITY_LENGTH_LIMIT)
            {
                WrongInputLabel.Text = string.Empty;
                CityTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = ErrorMessage;
                CityTextBox.BackColor = WrongInputColor;
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
            if (StreetTextBox.Text.Length <= Address.STREET_LENGTH_LIMIT)
            {
                WrongInputLabel.Text = string.Empty;
                StreetTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = ErrorMessage;
                StreetTextBox.BackColor = WrongInputColor;
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
            if (BuildingTextBox.Text.Length <= Address.BUILDING_LENGTH_LIMIT)
            {
                WrongInputLabel.Text = string.Empty;
                BuildingTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = ErrorMessage;
                BuildingTextBox.BackColor = WrongInputColor;
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
            if (ApartmentTextBox.Text.Length <= Address.APARTMENT_LENGTH_LIMIT)
            {
                WrongInputLabel.Text = string.Empty;
                ApartmentTextBox.BackColor = RightInputColor;
            }
            else
            {
                WrongInputLabel.Text = ErrorMessage;
                ApartmentTextBox.BackColor = WrongInputColor;
            }
        }

        /// <summary>
        /// Событие при выходе из текстового поля ввода почтового индекста доставки.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void PostIndexTextBox_Leave(object sender, EventArgs e)
        {
            if (PostIndexTextBox.BackColor == RightInputColor)
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
            if (CountryTextBox.BackColor == RightInputColor)
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
            if (CityTextBox.BackColor == RightInputColor)
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
            if (StreetTextBox.BackColor == RightInputColor)
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
            if (BuildingTextBox.BackColor == RightInputColor)
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
            if (ApartmentTextBox.BackColor == RightInputColor)
            {
                Address.Apartment = ApartmentTextBox.Text;
            }
            ApartmentTextBox.Text = Address.Apartment;
        }
    }
}
