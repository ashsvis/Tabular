using GridModel.Renderers;
using GridModel.Styles;
using System;

namespace GridModel.Cells
{
    [Serializable]
    public class Cell
    {
        /// <summary>
        /// Свойство стиля рисования ячейки
        /// </summary>
        public Style Style { get; private set; }

        /// <summary>
        /// Свойство рисовальщика ячейки
        /// </summary>
        public Renderer Renderer { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Конструктор ячейки для задания свойств по умолчанию
        /// </summary>
        public Cell()
        {
            Style = new Style();
            Renderer = new DefaultRenderer();
        }
    }
}
