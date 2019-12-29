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
    public partial class Categorys : ContentPage
    {
        /// <summary>
        /// список строк дохода
        /// </summary>
        List<models.TypePlus> plus { get; set; }

        /// <summary>
        /// список строк расхода
        /// </summary>
        List<models.TypeMinus> minus { get; set; }


        bool type { get; }
        /// <summary>
        /// инициализация
        /// </summary>
        /// <param name="type"> тип тру - доход - фалс - расход</param>
        public Categorys(bool type)
        {
            InitializeComponent();
            this.type = type;            
            GetData(type);                    
        }
        /// <summary>
        /// Получение списков из БД
        /// </summary>
        /// <param name="t"></param>
        async void GetData(bool t)
        {
            //bool type = (bool)t;
            if (type)
            {
                lvCategries.ItemsSource = await App.PlusDB.GetStringAsync();
                
            }
            else
            {
                lvCategries.ItemsSource = await App.MinusDB.GetStringAsync();
            }

        }

        /// <summary>
        /// Контекстное меню удаление из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            DisplayAlert("Чтото", mi.CommandParameter + " param", "ok"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void btnDelete_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            bool flag1 = int.TryParse(button.CommandParameter.ToString(),out int val);
            await DisplayAlert("ID", "Удаление категории: " + val, "ok");

            
            if (type) //из базы доходов
            {
                int? flag =-1;
                while (true)
                {
                    //flag = 
                        await App.PlusDB.DeleteValueAsync(val);
                    //if (flag.HasValue == false)
                    //{
                        break;
                    //}
                }
            }
            else
            {
                int? flag = -1;
                while (true)
                {
                    //flag = 
                        await App.MinusDB.DeleteValueAsync(val);
                    //if (flag.HasValue == false)
                    //{
                        break;
                    //}
                }
            }            
        }

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(enValue.Text))
                await DisplayAlert("!", "Введите значение", "OK");
            else
            {

                if (type)
                {
                    //var obj = new models.TypePlus(enValue.Text);
                    await App.PlusDB.SaveStringAsync(enValue.Text);
                }
                else
                {
                    await App.MinusDB.SaveStringAsync(enValue.Text);
                }
                GetData(type);
                enValue.Text = "";
            }
            
        }
    }
}