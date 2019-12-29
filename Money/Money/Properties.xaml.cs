using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Properties : ContentPage
    {
        public Properties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// редактирование списка возможных расходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnPropRash_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Categorys(false));
        }
        /// <summary>
        /// редактирование списка возможных доходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnPropDoh_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Categorys(true));
        }


        /// <summary>
        /// Создание файла для внешнего отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMakeFile_Clicked(object sender, EventArgs e)
        {

        }

        async private void BtnClearHistory_Clicked(object sender, EventArgs e)
        {
            
            bool answer = await DisplayAlert("ВНИМАНИЕ!", "Все записи будут удалены. Вы уверенны?", "Да. Удалить", "НЕТ");
            if (answer)
            {
                int col = 0;
                List<models.Stroka> list = App.Database.GetStroksAsync().Result;
                foreach (var i in list)
                {
                    col += await App.Database.DeleteStrokaAsync(i);
                }
                await DisplayAlert("Удаление","База данных отчищена.","OK");
            }
        }
    }
}