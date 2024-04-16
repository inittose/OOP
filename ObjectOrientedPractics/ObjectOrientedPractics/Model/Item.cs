using Newtonsoft.Json;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товаре.
    /// </summary>
    public class Item : ICloneable, IEquatable<Item>, IComparable<Item>
    {
        /// <summary>
        /// Максимальное число символов именования товара.
        /// </summary>
        public const int NameLengthLimit = 200;

        /// <summary>
        /// Максимальное число символов описания товара.
        /// </summary>
        public const int InfoLengthLimit = 1000;

        /// <summary>
        /// Минимальная цена товара.
        /// </summary>
        public const decimal MinimumCost = 0M;

        /// <summary>
        /// Максимальная цена товара.
        /// </summary>
        public const decimal MaximumCost = 100000M;

        /// <summary>
        /// Уникальный идентификатор товара.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Именование товара.
        /// </summary>
        private string _name;

        /// <summary>
        /// Описание товара.
        /// </summary>
        private string _info;

        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private decimal _cost;

        /// <summary>
        /// Событие при обновлении <see cref="Cost"/> объекта <see cref="Item"/>.
        /// </summary>
        public event EventHandler<EventArgs> CostChanged;

        /// <summary>
        /// Событие при обновлении <see cref="Name"/> объекта <see cref="Item"/>.
        /// </summary>
        public event EventHandler<EventArgs> NameChanged;

        /// <summary>
        /// Событие при обновлении <see cref="Info"/> объекта <see cref="Item"/>.
        /// </summary>
        public event EventHandler<EventArgs> InfoChanged;

        /// <summary>
        /// Возвращает и задает категорию товара объекта <see cref="Item"/>.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает уникальный идентификатор товара.
        /// </summary>
        /// TODO: сделать просто get и убрать поле _id.
        public int Id
        {
            get => _id;
        }

        /// <summary>
        /// Возвращает и задает наименование товара. 
        /// Должно состоять не более чем из 200 символов.
        /// </summary>
        public string Name
        {
            /// TODO: в одну строку.
            get
            {
                return _name;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, NameLengthLimit, nameof(Name));
                _name = value;
                NameChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Возвращает и задает описание товара. 
        /// Должно состоять не более чем из 1000 символов.
        /// </summary>
        public string Info
        {
            /// TODO: в одну строку.
            get
            {
                return _info;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, InfoLengthLimit, nameof(Info));
                _info = value;
                InfoChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Возвращает и задает стоимость товара. 
        /// Должна входить в диапозон: от 0 до 100 000.
        /// </summary>
        public decimal Cost
        {
            /// TODO: в одну строку.
            get
            {
                return _cost;
            }
            set
            {
                ValueValidator.AssertDecimalOnLimits(
                    value, 
                    MinimumCost, 
                    MaximumCost, 
                    nameof(Cost));

                _cost = value;
                CostChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        public Item()
        {
            _id = IdGenerator.GetNextId();
            Name = string.Empty;
            Info = string.Empty;
            Cost = 0;
            Category = Category.Other;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="name">
        ///     Именование товара. 
        ///     Должно состоять не более чем из 200 символов.
        /// </param>
        /// <param name="info">
        ///     Описание товара.
        ///     Должно состоять не более чем из 1000 символов.
        /// </param>
        /// <param name="cost">
        ///     Стоимость товара.
        ///     Должна входить в диапозон: от 0 до 100 000.
        ///</param>
        /// <param name="category">
        ///     Категория товара.
        ///</param>
        public Item(string name, string info, decimal cost, Category category)
        {
            _id = IdGenerator.GetNextId();
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="id">Ункиальный идентификатор.</param>
        [JsonConstructor]
        public Item(int id)
        {
            _id = id;
        }

        /// <summary>
        /// Создает копию объекта <see cref="Item"/>.
        /// </summary>
        /// <returns>Копия объекта в <see cref="object"/>.</returns>
        public object Clone()
        {
            var item = new Item(Id);
            item.Name = Name;
            item.Info = Info;
            item.Cost = Cost;
            item.Category = Category;

            return item;
        }

        /// <summary>
        /// Проверяет равенство исходного объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="Item"/>.</param>
        /// <returns>Возвращает булевое значение, равны ли объекты.</returns>
        public bool Equals(Item other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            // TODO: Для того, чтобы использовать корректно GetHashCode,...
            // его нужно переопределить в нужном классе...
            // и на основе всех значений объекта искать Hash
            return GetHashCode() == other.GetHashCode();
        }

        /// <summary>
        /// Сравнивает исходный объект с передаваемым.
        /// </summary>
        /// <param name="other">Объект класса <see cref="Item"/>.</param>
        /// <returns>
        /// 0 - Если цены равны;
        /// 1 - Если у исходного объекта цена выше;
        /// -1 - Если у передаваемого объекта цена выше.
        /// </returns>
        public int CompareTo(Item other)
        {
            if (Cost == other.Cost)
            {
                return 0;
            }
            else if (Cost > other.Cost)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
