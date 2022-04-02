using GridModel.Cells;
using System;
using System.Drawing;

namespace GridModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры
    /// </summary>
    [Serializable]
    public class DefaultRenderer : Renderer
    {
        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="cell">Ячейка со свойствами для рисования</param>
        public override void Render(Graphics graphics, Cell cell)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = cell.GetPath())
            {
                // если разрешено использование заливки
                if (cell.Style.FillStyle != null && cell.Style.FillStyle.IsVisible)
                    // то получаем кисть из стиля рисования фигуры
                    using (var brush = cell.Style.FillStyle.GetBrush(cell))
                        graphics.FillPath(brush, path);
                // если разрешено рисование контура
                if (cell.Style.BorderStyle != null && cell.Style.BorderStyle.IsVisible)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = cell.Style.BorderStyle.GetPen(cell))
                        graphics.DrawPath(pen, path);
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All; }
        }
    }
}
