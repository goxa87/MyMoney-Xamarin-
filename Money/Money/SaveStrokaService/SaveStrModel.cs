using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.Diagnostics;
using Money.models;

namespace Money
{
    class SaveStrModel : ISaveStrModel
    {
        async public void SaveChanges(Stroka str)
        {
            Debug.WriteLine("До сохранения");
            int rez = -1;
            rez= await App.Database.SaveStrokaAsync(str);
            Debug.WriteLine("После сохранения");
            if (rez > 0)
            {
                Page X = new Page();

                await X.DisplayAlert("Успешно", "Изменения успешно сохранены", "ОК");
            }

        }
    }
}
