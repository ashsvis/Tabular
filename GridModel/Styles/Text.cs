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
        /// <summary>
        /// Величина прозрачности цвета заливки текста
        /// </summary>
        public virtual int Opacity { get; set; }

        /// <summary>
        /// Цвет для заполнения фона (цвет заливки текста)
        /// </summary>
        public virtual Color Color { get; set; }

        public StringAlignment Alignment { get; set; }

        /// <summary>
        /// Имя файла шрифта
        /// </summary>
        public string FontName { get; set; } = "Segoe UI";

        /// <summary>
        /// Тип шрифта
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Признак возможности заливки текста
        /// </summary>
        public virtual bool IsVisible { get; set; } = true;

        public Brush GetBrush(Cell cell)
        {
            // возвращаем созданный и настроенный карандаш для контура ячейки
            return new SolidBrush(Color.FromArgb(Opacity, Color));
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
