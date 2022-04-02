using GridModel.Renderers;
using System;

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
    }
}
