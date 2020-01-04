using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Money
{
    /// <summary>
    /// Провайдер связи для сохранения на форме InfoDetials
    /// </summary>
    public class SaveStrProvider
    {
        ISaveStrModel model { get; set; }
        ISaveStrView view { get; set; }

        /// <summary>
        /// Провайдер для связи InfoDetails
        /// </summary>
        /// <param name="v">объект окна для связи</param>
        public SaveStrProvider(ISaveStrView v)
        {
            view = v;
            model = new SaveStrModel(); // модель поведения
        }

        /// <summary>
        /// действие сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Action(object sender, EventArgs e)
        {
            //изменяем объект
            view.theStroka.Note = view.Details;
            view.theStroka.Sum = view.Value;
            view.theStroka.Type = view.Category;
            //запускаем обработчик
            Debug.WriteLine("До провайдера");
            model.SaveChanges(view.theStroka);
                        
        }
    }
}
