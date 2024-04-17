using Newtonsoft.Json;
using ObjectOrientedPractices.Services;
using System.Collections.Generic;
using ObjectOrientedPractices.Model.Orders;
using ObjectOrientedPractices.Model.Discounts;

namespace ObjectOrientedPractices.Model
{
    /// <summary>
    /// Хранит данные о покупателе.
    /// </summary>
    public class Customer
    {
        /// TODO: не используется. Убрать
        /// UDP: Удалил

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Возвращает уникальный идентификатор покупателя.
        /// </summary>
        /// TODO: Сделать его на get без поля. Оно все равно в конструкторе устанавливается
        public int Id { get; }

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
                    value, ModelConstants.FullnameLengthLimit, nameof(_fullname));
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
            Id = IdGenerator.GetNextId();
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
            Id = IdGenerator.GetNextId();
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
            Id = id;
        }
    }
}
