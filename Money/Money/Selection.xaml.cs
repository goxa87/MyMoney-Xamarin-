using MoneyModelLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Selection : ContentPage
    {
        public Selection()
        {
            InitializeComponent();
            pickerType.ItemsSource = AddString.recordType.Types;
        }

        async private void BtnShow_Clicked(object sender, EventArgs e)
        {
            //
            DateTime start;
            if (chStartDate.IsChecked) start = dpStart.Date;
            else start = new DateTime(1900, 1, 1);

            DateTime end;
            if (chEndDate.IsChecked) end = dpEnd.Date;
            else end = DateTime.Today.AddDays(1);  // 00 00 00 это завтра т.е. если установить время 00 он не будет за жтото день отображать 


            //это работает правильно но сделано криво
            IEnumerable<Stroka> viborka;
            if (chDohod.IsChecked)
            {
                viborka = from S in await App.Database.GetStroksAsync()  // выбор по дате и сумме +
                          where S.Data >= start
                          where S.Data <= end
                          where S.Sum > 0
                          select S;
            }
            else
            {
                viborka = from S in await App.Database.GetStroksAsync()  // выбор по дате
                          where S.Data >= start
                          where S.Data <= end
                          select S;
                if (chType.IsChecked) // если строка помечена как параметр поиска
                {
                    viborka = from v in viborka
                              where v.Type == pickerType.SelectedItem.ToString()
                              select v;
                }
            }

            ObservableCollection<Stroka> rez2 = new ObservableCollection<Stroka>();
            viborka.ForEach((o) => rez2.Add(o));



            //// здесь какбы нужно присвоить rez результат линка но получается только это

            //var rez2 = new ObservableCollection<Stroka>(await App.Database.GetStroksAsync());

            await Navigation.PushAsync(new ListView(rez2));
        }
    }
}