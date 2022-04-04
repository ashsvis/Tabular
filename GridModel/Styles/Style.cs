using System;

namespace GridModel.Styles
{
    [Serializable]
    public class Style
    {
        /// <summary>
        /// Свойство для хранения данных для карандаша
        /// </summary>
        public Border BorderStyle { get; set; }

        /// <summary>
        /// Свойство для хранения данных кисти
        /// </summary>
        public Fill FillStyle { get; set; }


        /// <summary>
        /// Свойство для хранения данных кисти
        /// </summary>
        public Text TextStyle { get; set; }

        /// <summary>
        /// Конструктор стилей, для задания свойств по умолчанию
        /// </summary>
        public Style()
        {
            BorderStyle = new Border();
            FillStyle = new DefaultFill();
            TextStyle = new Text();
        }

    }
}
