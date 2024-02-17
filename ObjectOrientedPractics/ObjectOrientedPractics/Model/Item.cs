using System;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товаре.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Максимальное число символов именования товара.
        /// </summary>
        private static readonly int _nameLengthLimit = 200;

        /// <summary>
        /// Максимальное число символов описания товара.
        /// </summary>
        private static readonly int _infoLengthLimit = 1000;

        /// <summary>
        /// Минимальная цена товара.
        /// </summary>
        private static readonly float _minimumCost = 0f;

        /// <summary>
        /// Максимальная цена товара.
        /// </summary>
        private static readonly float _maximumCost = 100000f;

        /// <summary>
        /// Уникальный идентификатор данного товара.
        /// </summary>
        private readonly int _id = IdGenerator.GetNextId();

        /// <summary>
        /// Именование товара.
        /// </summary>
        private String _name;

        /// <summary>
        /// Описание товара.
        /// </summary>
        private String _info;

        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private float _cost;

        /// <summary>
        /// Возвращает максимальное число символов именования товара.
        /// </summary>
        public static int NameLengthLimit
        {
            get => _nameLengthLimit;
        }

        /// <summary>
        /// Возвращает максимальное число символов описания товара.
        /// </summary>
        public static int InfoLengthLimit
        {
            get => _infoLengthLimit;
        }

        /// <summary>
        /// Возвращает минимальную цену товара.
        /// </summary>
        public static float MinimumCost
        {
            get => _minimumCost;
        }

        /// <summary>
        /// Возвращает максимальную цену товара.
        /// </summary>
        public static float MaximumCost
        {
            get => _maximumCost;
        }

        /// <summary>
        /// Возвращает уникальный идентификатор данного товара.
        /// </summary>
        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
        }

        /// <summary>
        /// Возвращает и задает наименование товара. 
        /// Должно состоять не более чем из 200 символов.
        /// </summary>
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, NameLengthLimit, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает описание товара. 
        /// Должно состоять не более чем из 1000 символов.
        /// </summary>
        public String Info
        {
            get
            {
                return _info;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, InfoLengthLimit, nameof(Info));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает и задает стоимость товара. 
        /// Должна входить в диапозон: от 0 до 100 000.
        /// </summary>
        public float Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                ValueValidator.AssertFloatOnLimits(value, MinimumCost, MaximumCost, nameof(Cost));
                _cost = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        public Item()
        {
            Name = String.Empty;
            Info = String.Empty;
            Cost = 0;
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
        public Item(String name, String info, float cost)
        {
            Name = name;
            Info = info;
            Cost = cost;
        }
    }
}
