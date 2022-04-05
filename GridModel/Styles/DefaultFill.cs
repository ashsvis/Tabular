using GridModel.Cells;
using System;
using System.Drawing;

namespace GridModel.Styles
{
    /// <summary>
    /// Класс хранения данных заливки фигуры
    /// </summary>
    [Serializable]
    public class DefaultFill : Fill
    {
        private readonly AllowedFillDecorators allowedFillDecorators;

        /// <summary>
        /// Конструктор класса хранения данных заливки фигуры
        /// </summary>
        public DefaultFill(AllowedFillDecorators allowedDecorators = AllowedFillDecorators.All)
        {
            // по умолчанию заливка разрешена
            IsVisible = true;
            // по умолчанию белый цвет заливки
            Color = Color.White;
            // по умолчанию полная непрозрачность
            Opacity = 255;

            allowedFillDecorators = allowedDecorators;
        }

        /// <summary>
        /// Предоставление кисти для заливки ячейки
        /// </summary>
        /// <param name="cell">Ссылка на ячейку</param>
        /// <returns>Возвращаем настроенную кисть</returns>
        public override Brush GetBrush(Cell cell)
        {
            // возвращаем созданную и настроенную кисть для ячейки
            return new SolidBrush(Color.FromArgb(Opacity, Color));
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedFillDecorators AllowedDecorators
        {
            get { return allowedFillDecorators; }
        }
    }
}
