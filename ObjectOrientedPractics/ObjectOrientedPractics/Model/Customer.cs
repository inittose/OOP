using Newtonsoft.Json;
using ObjectOrientedPractics.Services;
using System.Collections.Generic;
using ObjectOrientedPractics.Model.Orders;
using ObjectOrientedPractics.Model.Discounts;

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
        public const int FullnameLengthLimit = 200;

        /// <summary>
        /// Максимальное число символов адреса покупателя.
        /// </summary>
        /// TODO: не используется. Убрать
        public const int AddressLengthLimit = 500;

        /// <summary>
        /// Уникальный идентификатор покупателя.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Возвращает уникальный идентификатор покупателя.
        /// </summary>
        /// TODO: Сделать его на get без поля. Оно все равно в конструкторе устанавливается
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
                    value, FullnameLengthLimit, nameof(_fullname));
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
        /// Возвращает и задает список заказов покупателя.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Возвращает и задает флаг, приоритетный ли покупатель.
        /// </summary>
        public bool IsPriority { get; set; } = false;

        /// <summary>
        /// Возвращает и задает скидки покупателя.
        /// </summary>
        public List<IDiscount> Discounts { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            _id = IdGenerator.GetNextId();
            FullName = string.Empty;
            Address = new Address();
            Discounts = new List<IDiscount>();
            Discounts.Add(new PointsDiscount());
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
            _id = IdGenerator.GetNextId();
            FullName = fullname;
            Address = address;
            Discounts = new List<IDiscount>();
            Discounts.Add(new PointsDiscount());
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        [JsonConstructor]
        public Customer(int id)
        {
            _id = id;
        }
    }
}
