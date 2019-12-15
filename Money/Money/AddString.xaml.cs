using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddString : ContentPage
    {
        /// <summary>
        /// Знак операции - списание + начисление
        /// </summary>
        bool currentSign { get; set; }
        
        public AddString()
        {
            InitializeComponent();
            currentSign = false;


            var rez = App.MinusDB.GetStringAsync().Result.Select(p => new { str = p.Value });
            // дикий костыль  
            List<string> arr = new List<string>();
            foreach (var a in rez)
                arr.Add(a.str);
            picerType.ItemsSource = arr;
            picerType.SelectedIndex = 0;
            
        }

        /// <summary>
        /// Изменение знака суммы операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSign_Clicked(object sender, EventArgs e)
        {
            if (currentSign)
            {
                currentSign = false;
                btnSign.Text = "-";
                var rez = App.MinusDB.GetStringAsync().Result.Select(p => new { str = p.Value });
                // дикий костыль  
                List<string> arr = new List<string>();
                foreach (var a in rez)
                    arr.Add(a.str);
                picerType.ItemsSource = arr;
                picerType.SelectedIndex = 0;
            }
            else
            {
                currentSign = true;
                btnSign.Text = "+";
                var rez = App.PlusDB.GetStringAsync().Result.Select(p => new { str = p.Value });
                // дикий костыль  
                List<string> arr = new List<string>();
                foreach (var a in rez)
                    arr.Add(a.str);
                picerType.ItemsSource = arr;
                picerType.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// При событии обработки ошибки для типов записей
        /// </summary>
        /// <param name="s">сообщение</param>
        /// <param name="i">номер ошибки </param>
        async private void OnTypeException(string s, int i)
        {
            await DisplayAlert("Ошибка типов записей.", s + $": #{i}", "ОК");
        }

        /// <summary>
        /// добавление Записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddString_Clicked(object sender, EventArgs e)
        {
            //Проверить содержание поля на не 0
            //2 параллельных потока для значка процесса и для соxранения с задержкой
            if (!string.IsNullOrWhiteSpace(entSum.Text))
            {
                SaveString();
            }
            else //
            {
                OnTypeException("Пустая строка", 75);
            }
        }

        
        /// <summary>
        /// Сохранение записи с этой строки
        /// </summary>
        async void SaveString()
        {
            
            try
            {
                int Sum = 0;  
                bool flag = int.TryParse(entSum.Text, out Sum);
                if (!flag)
                    throw new FormatException("Проблемы с вводом значения");

                models.Stroka rez = new models.Stroka(Sum,currentSign,picerType.SelectedItem.ToString(),entryNote.Text);
                //App.book.Book.Add(rez);
                await App.Database.SaveStrokaAsync(rez);

                await DisplayAlert("Успешно", "Запись успешно добавлена", "OK");
                entSum.Text = null;
                entryNote.Text = null;
            }
            catch (FormatException ex)
            {
                OnTypeException(ex.Message, 104);
            }
            catch (Exception ex)
            {
                OnTypeException(ex.Message, 108);
            }
                
        }
    }
}