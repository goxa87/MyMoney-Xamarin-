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

            Task.Factory.StartNew(GetContent);            
        }

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
    }
}