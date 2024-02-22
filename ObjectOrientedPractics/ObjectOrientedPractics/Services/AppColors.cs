using System.Drawing;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Services
{
    public static class AppColors
    {
        /// <summary>
        /// Цвет <see cref="TextBox"/>, успешно прошедшего валидацию. 
        /// </summary>
        public static Color RightInputColor { get; } = Color.White;

        /// <summary>
        /// Цвет <see cref="TextBox"/>, неудачно прошедшего валидацию. 
        /// </summary>
        public static Color WrongInputColor { get; } = Color.Red;
    }
}
