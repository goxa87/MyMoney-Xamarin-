﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using System;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Selection : ContentPage
    {
        public Selection()
        {
            InitializeComponent();
            dpStart.Date = DateTime.Today.AddDays(-1);

            // заполнение пикера категориями минусом и плюсовыми
            var arr1 = App.MinusDB.GetStringAsync().Result.Select(p => new { str = p.Value });
            var arr2 = App.PlusDB.GetStringAsync().Result.Select(p => new { str = p.Value });
            var rez = arr1.Union(arr2).ToList();
            // дикий костыль  
            // 
            List<string> arr = new List<string>();
            foreach (var a in rez)
                arr.Add(a.str);
            pickerType.ItemsSource = arr;
            
        }
        /// <summary>
        /// Показать выборку по параметрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            IEnumerable<models.Stroka> viborka;
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

            List<models.Stroka> rez2 = new List<models.Stroka>();
            viborka.ForEach((o) => rez2.Add(o));

            await Navigation.PushAsync(new ListView(rez2.OrderByDescending(el => el.Data).ToList()));
        }
    }
}