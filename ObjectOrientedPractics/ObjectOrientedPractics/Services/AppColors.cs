using System.Drawing;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит цвета <see cref="Color"/> для программы.
    /// </summary>
    public static class AppColors
    {
        /// <summary>
        /// Возвращает цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        public static Color RightInputColor { get; } = Color.White;

        /// <summary>
        /// Возвращает цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        public static Color WrongInputColor { get; } = Color.LightPink;
    }
}
