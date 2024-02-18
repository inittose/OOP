using System;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о покупателе.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Максимальное число символов имени покупателя.
        /// </summary>
        public const int FULLNAME_LENGTH_LIMIT = 200;

        /// <summary>
        /// Максимальное число символов адреса покупателя.
        /// </summary>
        public const int ADDRESS_LENGTH_LIMIT = 500;

        /// <summary>
        /// Уникальный идентификатор данного покупателя.
        /// </summary>
        private readonly int _id = IdGenerator.GetNextId();

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Адрес доставки покупателя.
        /// </summary>
        private string _address;

        /// <summary>
        /// Возвращает уникальный идентификатор данного покупателя.
        /// </summary>
        public int Id
        {
            get => _id;
        }

        /// <summary>
        /// Возвращает и задает имя покупателя. 
        /// Должно состоять не более чем из 200 символов.
        /// </summary>
        public string FullName
        {
            get => _fullname;
            set
            {
                ValueValidator.AssertStringOnLength(
                    value, FULLNAME_LENGTH_LIMIT, nameof(_fullname));
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задает адрес доставки покупателя. 
        /// Должен состоять не более чем из 500 символов.
        /// </summary>
        public string Address
        {
            get => _address;
            set
            {
                ValueValidator.AssertStringOnLength(value, ADDRESS_LENGTH_LIMIT, nameof(_address));
                _address = value;
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            FullName = String.Empty;
            Address = String.Empty;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">
        ///     Полное имя покупателя.
        ///     Должно состоять не более чем из 200 символов.
        /// </param>
        /// <param name="address">
        ///     Адрес доставки покупателя.
        ///     Должно состоять не более чем из 500 символов.
        /// </param>
        public Customer(String fullname, String address)
        {
            FullName = fullname;
            Address = address;
        }
    }
}
