using GridModel.Cells;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        public override void Render(Graphics graphics, Rectangle rect, Cell cell)
        {
            if (cell == null) return;
            // получаем путь для рисования, трансформированный методом ячейки
            using (var path = new GraphicsPath())
            {
                path.AddRectangle(rect);
                // если разрешено использование заливки
                if (cell.Style.FillStyle != null && cell.Style.FillStyle.IsVisible)
                {
                    // то получаем кисть из стиля рисования ячейки
                    using (var brush = cell.Style.FillStyle.GetBrush(cell))
                        graphics.FillPath(brush, path);
                }
                // если разрешено рисование контура
                if (cell.Style.BorderStyle != null && cell.Style.BorderStyle.IsVisible)
                {
                    // то получаем карандаш из стиля рисования ячейки
                    using (var pen = cell.Style.BorderStyle.GetPen(cell))
                        graphics.DrawPath(pen, path);
                }
                if (cell.Style.TextStyle != null && cell.Style.TextStyle.IsVisible && !string.IsNullOrWhiteSpace(cell.Text))
                {
                    using (var sf = new StringFormat(StringFormat.GenericTypographic))
                    {
                        sf.Alignment = cell.Style.TextStyle.Alignment;
                        sf.LineAlignment = cell.Style.TextStyle.LineAlignment;
                        using (var brush = cell.Style.TextStyle.GetBrush(cell))
                        using (var font = cell.Style.TextStyle.GetFont(cell))
                        {
                            rect.Inflate(-1, 2);
                            graphics.DrawString(cell.Text, font, brush, rect, sf);
                        }
                    }
                }
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
