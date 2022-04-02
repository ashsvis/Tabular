using GridModel.Renderers;
using System;
using System.Drawing.Drawing2D;

namespace GridModel.Cells
{
    [Serializable]
    public class Cell
    {
        /// <summary>
        /// Свойство стиля рисования ячейки
        /// </summary>
        public Styles.Style Style { get; private set; }

        /// <summary>
        /// Свойство рисовальщика ячейки
        /// </summary>
        public Renderer Renderer { get; set; }

        /// <summary>
        /// Конструктор ячейки для задания свойств по умолчанию
        /// </summary>
        public Cell()
        {
            Style = new Styles.Style();
            Renderer = new DefaultRenderer();
        }

        /// <summary>
        /// Предоставление геометрии для рисования
        /// </summary>
        /// <returns>Путь для рисования</returns>
        public virtual GraphicsPath GetPath()
        {
            // создаём геометрии ячейки
            var path = new GraphicsPath();
            return path;
        }
    }
}
