using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Excel = Microsoft.Office.Interop.Excel;

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
                await DisplayAlert("Удаление","База данных очищена.","OK");
            }
        }
        
        /// <summary>
        /// Несколько алертов для информации 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnInfo_Clicked(object sender, EventArgs e)
        {
            bool rezult = await DisplayAlert("Информация", "Данная программа поможет вам вести учет финансов. Удобство в том, что ввод новой записи происходит на первой" +
                      " странице, что позволяет вносить изменения быстро.", "Дальше", "Хватит");
            if (rezult)
            {
                bool rezult2 = await DisplayAlert("Обновления", "Для обратной связи, получения обновлений и дополнительной информации можете обратиться к разработчику в Telegram по нику @Georgy_Milk",
                  "Дальше", "Хватит");
                if (rezult2)
                {
                    await DisplayAlert("Спасибо!", "Спасибо, что пользуетесь этой программой, я надеюсь она вам нравится. Если у вас есть непреодолимое желание " +
                        "отблагодарить разработчика, можете его не преодолевать и поблагодарить на карту Cбера \n4276 6000 4052 8859 - Георгий Николаевич.", "Хорошо)");
                }
            }
        }
    }
}