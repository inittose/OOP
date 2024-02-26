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
        /// Возвращает и задает адрес доставки покупателя класса <see cref="Model.Address"/>. 
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Возвращает и задает корзину покупателя.
        /// </summary>
        public Cart Cart { get; set; } = new Cart();

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            FullName = string.Empty;
            Address = new Address();
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">
        ///     Полное имя покупателя.
        ///     Должно состоять не более чем из 200 символов.
        /// </param>
        /// <param name="address">
        ///     Адрес доставки покупателя класса <see cref="Model.Address"/>.
        /// </param>
        public Customer(string fullname, Address address)
        {
            FullName = fullname;
            Address = address;
        }
    }
}
