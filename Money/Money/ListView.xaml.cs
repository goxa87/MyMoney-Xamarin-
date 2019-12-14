using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage
    {
        //ObservableCollection<models.Stroka> list { get; }
        /// <summary>
        /// Список переданных записей
        /// </summary>
        List<models.Stroka> List { get; }
               
        /// <summary>
        /// Инициализайия
        /// </summary>
        /// <param name="list"> записи для отображения</param>
        public ListView(List<models.Stroka> list)
        {
            InitializeComponent();
            List = list;
            lvViborka.ItemsSource = List;
        }
        /// <summary>
        /// Переключение на собрать по категориям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwCaregory_Toggled(object sender, ToggledEventArgs e)
        {
            if (swCaregory.IsToggled) // если он выкюлючен выводим собранные по категориям
            {
                var rez = List.GroupBy(t => t.Type, s=>s.Sum).Select(p => new
                {
                    Type = p.Key,
                    Sum = p.Sum()
                });

                lvViborka.ItemsSource = rez;
            }
            else
            {
                lvViborka.ItemsSource = List;
            }
        }
    }
}
