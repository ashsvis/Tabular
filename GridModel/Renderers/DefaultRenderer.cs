﻿using GridModel.Cells;
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
                if (cell.Style.TextStyle != null && cell.Style.TextStyle.IsVisible && !string.IsNullOrWhiteSpace(cell.Text))
                {
                    using (var sf = new StringFormat(StringFormat.GenericTypographic))
                    {
                        sf.Alignment = cell.Style.TextStyle.Alignment;
                        path.AddString(cell.Text, new FontFamily(cell.Style.TextStyle.FontName), (int)cell.Style.TextStyle.FontStyle, 14f, PointF.Empty, sf);
                    }
                }
                // если разрешено рисование контура
                if (cell.Style.BorderStyle != null && cell.Style.BorderStyle.IsVisible)
                {
                    // то получаем карандаш из стиля рисования ячейки
                    using (var pen = cell.Style.BorderStyle.GetPen(cell))
                        graphics.DrawPath(pen, path);
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