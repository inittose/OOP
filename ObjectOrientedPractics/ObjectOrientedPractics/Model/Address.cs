using ObjectOrientedPractics.Services;
using System;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные об адресе доставки.
    /// </summary>
    public class Address : ICloneable, IEquatable<Address>
    {
        /// <summary>
        /// Разряд почтового индекса.
        /// </summary>
        public const int IndexDigit = 6;

        /// <summary>
        /// Максимальное число символов названия страны.
        /// </summary>
        public const int CountryLengthLimit = 50;

        /// <summary>
        /// Максимальное число символов названия города.
        /// </summary>
        public const int CityLengthLimit = 50;

        /// <summary>
        /// Максимальное число символов названии улицы.
        /// </summary>
        public const int StreetLengthLimit = 100;

        /// <summary>
        /// Максимальное число символов номера дома.
        /// </summary>
        public const int BuildingLengthLimit = 10;

        /// <summary>
        /// Максимальное число символов номера квартиры/помещения.
        /// </summary>
        public const int ApartmentLengthLimit = 10;

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
        /// Событие при обновлении любого поля объекта <see cref="Address"/>.
        /// </summary>
        public event EventHandler<EventArgs> AddressChanged;

        /// <summary>
        /// Возвращает и задает почтовый индекс.
        /// </summary>
        public int Index
        {
            get => _index;
            set
            {
                ValueValidator.AssertIntOnDigit(value, IndexDigit, nameof(Index));
                _index = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
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
                ValueValidator.AssertStringOnLength(value, CountryLengthLimit, nameof(Country));
                _country = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
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
                ValueValidator.AssertStringOnLength(value, CityLengthLimit, nameof(City));
                _city = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
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
                ValueValidator.AssertStringOnLength(value, StreetLengthLimit, nameof(Street));
                _street = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
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
                ValueValidator.AssertStringOnLength(
                    value, 
                    BuildingLengthLimit, 
                    nameof(Building));

                _building = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
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
                ValueValidator.AssertStringOnLength(
                    value, 
                    ApartmentLengthLimit, 
                    nameof(Apartment));

                _apartment = value;
                AddressChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// TODO: грамм ошибка
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
        /// TODO: грамм ошибка
        /// Создает экзепляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Почтовый индекс.</param>
        /// <param name="country">Страна.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="building">Номер здания.</param>
        /// <param name="apartment">Номер квартиры/помещения.</param>
        public Address(
            int index, 
            string country, 
            string city,
            string street, 
            string building, 
            string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }

        /// <summary>
        /// Создает копию объекта <see cref="Address"/>.
        /// </summary>
        /// <returns>Копия объекта в <see cref="object"/>.</returns>
        public object Clone()
        {
            return new Address(
                Index, 
                Country, 
                City, 
                Street, 
                Building, 
                Apartment);
        }

        /// <summary>
        /// Проверяет равенство исходного объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="Address"/>.</param>
        /// <returns>Возвращает булевое значение, равны ли объекты.</returns>
        public bool Equals(Address other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return GetHashCode() == other.GetHashCode();
        }
    }
}
