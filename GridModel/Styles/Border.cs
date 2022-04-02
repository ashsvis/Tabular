﻿using GridModel.Cells;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GridModel.Styles
{
    [Serializable]
    public class Border
    {
        /// <summary>
        /// Конструктор класса хранения данных контура
        /// </summary>
        public Border()
        {
            // по умолчанию заливка разрешена
            IsVisible = true;
            // по умолчанию полная непрозрачность
            Opacity = 255;
            // по умолчанию чёрный цвет контура
            Color = Color.Black;
            // по умолчанию 1 единица
            Width = 1f;
            // по умолчанию сплошная линия
            DashStyle = DashStyle.Solid;
        }

        /// <summary>
        /// Величина прозрачности цвета контура
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// Толщина линии для рисования контура
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Цвет для рисования контура (цвет карандаша)
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Признак возможности рисования контура
        /// </summary>
        public bool IsVisible { get; set; }

        public DashStyle DashStyle { get; set; }

        /// <summary>
        /// Предоставление карандаша для рисования контура
        /// </summary>
        /// <param name="cell">Ссылка на ячейку</param>
        /// <returns></returns>
        public Pen GetPen(Cell cell)
        {
            // возвращаем созданный и настроенный карандаш для контура ячейки
            return new Pen(Color.FromArgb(Opacity, Color), Width) { DashStyle = DashStyle };
        }
    }
}
