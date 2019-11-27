using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyModelLibrary;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddString : ContentPage
    {
        /// <summary>
        /// Знак операции - списание + начисление
        /// </summary>
        bool currentSign { get; set; }

        /// <summary>
        /// список типов записей
        /// </summary>
        public static RecordType recordType { get; set; }

        /// <summary>
        /// для статического поля
        /// </summary>
        static AddString()
        {
            recordType = new RecordType((string s,int i) => { });
        }

        public AddString()
        {
            InitializeComponent();
            currentSign = false;
            //recordType = new RecordType(OnTypeException);
            picerType.ItemsSource = recordType.Types;

            //picerType.ItemsSource = new List<string> { "food", "water", "grass" };
            // сделать если не пустое
            picerType.SelectedIndex = 0;
            //App.recordType.CallExMethod += OnTypeException;
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
            }
            else
            {
                currentSign = true;
                btnSign.Text = "+";
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

                Stroka rez = new Stroka(Sum,currentSign,picerType.SelectedItem.ToString(),entryNote.Text);
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