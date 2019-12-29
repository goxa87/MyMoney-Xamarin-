using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Properties : ContentPage, IPropertiesView
    {
        PropertiesPageProvider provider { get; set; }


        public Properties()
        {
            InitializeComponent();
            provider = new PropertiesPageProvider(new GetFileService(), this);

            //btnClearHistory.Clicked += provider.SaveFileOperation;
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
        /// отчистить историю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void BtnMakeFile_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("метод в код бихайнд");
            provider.SaveFileOperation(this,new EventArgs());
        }
    }
}