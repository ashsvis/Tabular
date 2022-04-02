using GridModel.Cells;
using System;
using System.Drawing;

namespace GridModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика
    /// </summary>
    [Serializable]
    public abstract class Renderer
    {
        /// <summary>
        /// Метод отрисовки ячейки на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="cell">ячейка со свойствами для рисования</param>
        public abstract void Render(Graphics graphics, Cell cell);

        /// <summary>
        /// Допустимые операции над геометрией
        /// </summary>
        public abstract AllowedRendererDecorators AllowedDecorators { get; }
    }

    /// <summary>
    /// Допустимые операции над геометрией
    /// </summary>
    [Serializable]
    [Flags]
    public enum AllowedRendererDecorators : uint
    {
        None = 0x0,         // ничего нельзя
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }
}
