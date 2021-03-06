using GridModel.Cells;
using System;
using System.Drawing;

namespace GridModel.Styles
{
    /// <summary>
    /// Класс рисовальщика фона
    /// </summary>
    [Serializable]
    public abstract class Fill
    {
        /// <summary>
        /// Величина прозрачности цвета заливки
        /// </summary>
        public virtual int Opacity { get; set; }

        /// <summary>
        /// Цвет для заполнения фона (цвет заливки)
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// Признак возможности заливки фигуры
        /// </summary>
        public virtual bool IsVisible { get; set; }

        public abstract Brush GetBrush(Cell cell);

        /// <summary>
        /// Допустимые операции над геометрией
        /// </summary>
        public abstract AllowedFillDecorators AllowedDecorators { get; }
    }

    /// <summary>
    /// Допустимые операции над заливкой
    /// </summary>
    [Serializable]
    [Flags]
    public enum AllowedFillDecorators : uint
    {
        None = 0x0,             // ничего нельзя
        LinearGradient = 0x1,   // может задавать линейный градиент
        RadialGradient = 0x2,   // может задавать радиальный градиент
        Hatch = 0x4,            // может задавать штриховку
        Texture = 0x8,          // может задавать текстуру
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }
}
