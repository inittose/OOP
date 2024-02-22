using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные об адресе доставки.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Разряд почтового индекса.
        /// </summary>
        public const int INDEX_DIGIT = 6;

        /// <summary>
        /// Максимальное число символов названия страны.
        /// </summary>
        public const int COUNTRY_LENGTH_LIMIT = 50;

        /// <summary>
        /// Максимальное число символов названия города.
        /// </summary>
        public const int CITY_LENGTH_LIMIT = 50;

        /// <summary>
        /// Максимальное число символов названии улицы.
        /// </summary>
        public const int STREET_LENGTH_LIMIT = 100;

        /// <summary>
        /// Максимальное число символов номера дома.
        /// </summary>
        public const int BUILDING_LENGTH_LIMIT = 10;

        /// <summary>
        /// Максимальное число символов номера квартиры/помещения.
        /// </summary>
        public const int APARTMENT_LENGTH_LIMIT = 10;

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        private int _index;

        /// <summary>
        /// Страна.
        /// </summary>
        private string _country;

        /// <summary>
        /// Город.
        /// </summary>
        private string _city;

        /// <summary>
        /// Улица.
        /// </summary>
        private string _street;

        /// <summary>
        /// Номер здания.
        /// </summary>
        private string _building;

        /// <summary>
        /// Номер квартиры/помещения.
        /// </summary>
        private string _apartment;

        /// <summary>
        /// Возвращает и задает почтовый индекс.
        /// </summary>
        public int Index
        {
            get => _index;
            set
            {
                ValueValidator.AssertIntOnDigit(value, INDEX_DIGIT, nameof(Index));
                _index = value;
            }
        }

        /// <summary>
        /// Возвращает и задает страну.
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                ValueValidator.AssertStringOnLength(value, COUNTRY_LENGTH_LIMIT, nameof(Country));
                _country = value;
            }
        }

        /// <summary>
        /// Возвращает и задает город.
        /// </summary>
        public string City
        {
            get => _city;
            set
            {
                ValueValidator.AssertStringOnLength(value, CITY_LENGTH_LIMIT, nameof(City));
                _city = value;
            }
        }

        /// <summary>
        /// Возвращает и задает улицу.
        /// </summary>
        public string Street
        {
            get => _street;
            set
            {
                ValueValidator.AssertStringOnLength(value, STREET_LENGTH_LIMIT, nameof(Street));
                _street = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номер здания.
        /// </summary>
        public string Building
        {
            get => _building;
            set
            {
                ValueValidator.AssertStringOnLength(value, BUILDING_LENGTH_LIMIT, nameof(Building));
                _building = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номер квартиры/помещения.
        /// </summary>
        public string Apartment
        {
            get => _apartment;
            set
            {
                ValueValidator.AssertStringOnLength(value, APARTMENT_LENGTH_LIMIT, nameof(Apartment));
                _apartment = value;
            }
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Address"/>.
        /// </summary>
        public Address()
        {
            Index = 999999;
            Country = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            Building = string.Empty;
            Apartment = string.Empty;
        }

        /// <summary>
        /// Создает экзепляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Почтовый индекс.</param>
        /// <param name="country">Страна.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="building">Номер здания.</param>
        /// <param name="apartment">Номер квартиры/помещения.</param>
        public Address(int index, string country, string city, 
                                        string street, string building, string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }
    }
}
