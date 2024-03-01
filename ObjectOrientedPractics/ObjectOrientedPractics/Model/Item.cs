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
        public const int NAME_LENGTH_LIMIT = 200;

        /// <summary>
        /// Максимальное число символов описания товара.
        /// </summary>
        public const int INFO_LENGTH_LIMIT = 1000;

        /// <summary>
        /// Минимальная цена товара.
        /// </summary>
        public const float MINIMUM_COST = 0f;

        /// <summary>
        /// Максимальная цена товара.
        /// </summary>
        public const float MAXIMUM_COST = 100000f;

        /// <summary>
        /// Уникальный идентификатор данного товара.
        /// </summary>
        private readonly int _id = IdGenerator.GetNextId();

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
        private float _cost;

        /// <summary>
        /// Возвращает и задает категорию товара объекта <see cref="Item"/>.
        /// </summary>
        public Category Category { get; set; }

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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, NAME_LENGTH_LIMIT, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает описание товара. 
        /// Должно состоять не более чем из 1000 символов.
        /// </summary>
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, INFO_LENGTH_LIMIT, nameof(Info));
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
                ValueValidator.AssertFloatOnLimits(
                    value, MINIMUM_COST, MAXIMUM_COST, nameof(Cost));
                _cost = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>.
        /// </summary>
        public Item()
        {
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
        public Item(string name, string info, float cost, Category category)
        {
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
        }
    }
}
