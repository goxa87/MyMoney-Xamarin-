using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Mone

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Report : ContentPage
    {
        
        public Report()
        {
            InitializeComponent();
            
            // заполнение значениями
            Task.Factory.StartNew(GetContent);            
        }

        /// <summary>
        /// при появлении получить новыен данные
        /// </summary>
        protected override void OnAppearing()
        {
            GetContent();
        }

        /// <summary>
        /// получения значений для заполнения формы
        /// </summary>
        void GetContent()
        {
            //List<Stroka> lis 
            int curP = 0; // текущ +
            int curM = 0; // текцщ минус
            int lastP = 0; // пред +
            int lastM = 0; // пред -
            int totP = 0;  // всего+ 
            int totM = 0; // всего -

            DateTime curD = DateTime.Now;

            // это передаелать на другой интерфейс 
            // по типу в заголовке выбор месяца. поумолчанию текущий
            // внизу всего

            List<models.Stroka> list = App.Database.GetStroksAsync().Result;
            foreach (var e in list)
            {
                if (e.Data.Month == DateTime.Now.Month) // этот месяц
                {
                    if (e.Sign) curP += e.Sum; else curM += e.Sum;
                    if (e.Sign) totP += e.Sum; else totM += e.Sum; // в тотал тоже
                }
                else
                {
                    if (e.Data.Month == DateTime.Now.AddMonths(-1).Month) // прошлый месяц
                    {
                        if (e.Sign) lastP += e.Sum; else lastM += e.Sum;
                        if (e.Sign) totP += e.Sum; else totM += e.Sum;  // в тотал
                    }
                    else // если не прошлый и не текущий
                    {
                        if (e.Sign) totP += e.Sum; else totM += e.Sum;  // только тотал
                    }
                }
            }
            //заполнение полей в интерфейсе
            lblCurPlus.Text = curP.ToString();
            lblCurDis.Text = curM.ToString();
            lblLastPlus.Text = lastP.ToString();
            lblLastDis.Text = lastM.ToString();
            lblTotalPlus.Text = totP.ToString();
            lblTotalDis.Text = totM.ToString();
        }




        // ПРЕНЕСТИ В 4 СТРАНИЦУ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ClearHistory(object sender, EventArgs e)
        {
            /// это перенести куданить дальше в настройки
            bool answer = await DisplayAlert("ВНИМАНИЕ!", "Все записи будут удалены. Вы уверенны?", "Да. Удалить", "НЕТ");
            if(answer)
            {
                int col = 0;
                List<models.Stroka> list = App.Database.GetStroksAsync().Result;
                foreach (var i in list)
                {
                    col+= await App.Database.DeleteStrokaAsync(i);
                }

                lblCurPlus.Text = "0";
                lblCurDis.Text = "0";
                lblLastPlus.Text = "0";
                lblLastDis.Text = "0";
                lblTotalPlus.Text = "0";
                lblTotalDis.Text = "0";
            }
        }

        /// <summary>
        /// Вызов выборки для текущего месяца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnCurDetail_Clicked(object sender, EventArgs e)
        {
            List<models.Stroka> data = App.Database.GetStroksAsync().Result;

            DateTime start = new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);  // этот мес 1 число
            DateTime end = new DateTime((DateTime.Today.AddMonths(1).Year), DateTime.Today.AddMonths(1).Month, 1 );   // след мес первое число
 
            data = data.Where(d => d.Data > start
            && (d.Data< end)).ToList();

            await Navigation.PushAsync(new ListView(data));

        }

        /// <summary>
        /// Вызов выборки для прошлого месяца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnLastDetail_Clicked(object sender, EventArgs e)
        {
            List<models.Stroka> data = App.Database.GetStroksAsync().Result;

            DateTime start = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1); // пред мес 1 число
            DateTime end = new DateTime((DateTime.Today.Year), DateTime.Today.Month, 1);  // этот мес 1 число 00 ч 00 мин

            data = data.Where(d => d.Data > start
            && d.Data<end).ToList();

            await Navigation.PushAsync(new ListView(data));
        }



        /// <summary>
        /// Вызов выборки для всего периода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTotalDetail_Clicked(object sender, EventArgs e)
        {

        }
    }
}