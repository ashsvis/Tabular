using GridModel.Cells;
using System;
using System.Drawing;

namespace GridModel.Styles
{
    /// <summary>
    /// Класс рисовальщика фона
    /// </summary>
    [Serializable]
    public class Text
    {
        public Text()
        {
            // по умолчанию текст разрешён
            IsVisible = true;
            // по умолчанию полная непрозрачность
            Opacity = 255;
            // по умолчанию чёрный цвет шрифта
            Color = Color.Black;
            Alignment = StringAlignment.Near;
            LineAlignment = StringAlignment.Center;
            FontName = "Segoe UI";
            // по умолчанию 8 единиц
            FontSize = 8f;
            FontStyle = FontStyle.Regular;
        }

        /// <summary>
        /// Величина прозрачности цвета заливки текста
        /// </summary>
        public virtual int Opacity { get; set; }

        /// <summary>
        /// Цвет для заливки текста
        /// </summary>
        public virtual Color Color { get; set; }

        public StringAlignment Alignment { get; set; }
        public StringAlignment LineAlignment { get; set; }

        /// <summary>
        /// Имя файла шрифта
        /// </summary>
        public string FontName { get; set; }
        public float FontSize { get; set; }

        /// <summary>
        /// Тип шрифта
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Предоставление кисти для заливки ячейки
        /// </summary>
        /// <param name="cell">Ссылка на ячейку</param>
        /// <returns>Возвращаем настроенную кисть</returns>
        public virtual Brush GetBrush(Cell cell)
        {
            // возвращаем созданную и настроенную кисть для ячейки
            return new SolidBrush(Color.FromArgb(Opacity, Color));
        }

        /// <summary>
        /// Признак возможности заливки текста
        /// </summary>
        public virtual bool IsVisible { get; set; } = true;

        public Font GetFont(Cell cell)
        {
            // возвращаем созданный и настроенный карандаш для контура ячейки
            return new Font(FontName, FontSize, FontStyle);
        }

        /// <summary>
        /// Допустимые операции над геометрией
        /// </summary>
        public AllowedTextDecorators AllowedDecorators { get; }
    }

    /// <summary>
    /// Допустимые операции над заливкой
    /// </summary>
    [Serializable]
    [Flags]
    public enum AllowedTextDecorators : uint
    {
        None = 0x0,             // ничего нельзя
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }
}
