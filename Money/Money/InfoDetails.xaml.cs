using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Money.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoDetails : ContentPage, ISaveStrView
    {     
        SaveStrProvider provider { get; set; }

        public InfoDetails(models.Stroka str)
        {
            InitializeComponent();
            provider = new SaveStrProvider(this);
            theStroka = str;
            // заполнение формы на входе
            Value = str.Sum;
            Category = str.Type;
            Details = str.Note;
            string sign = str.Sign ? "+" : " ";
            //заголовочек
            txtTitle.Text = $"Запись#{str.ID}: {sign}{str.Sum} - {str.Type} ";

            //btnSaveChanges.Clicked += provider.Action;
            //btnSaveChanges.Clicked += (s, e) =>
            //  {
            //      DisplayAlert("Изменения", "Запись сохранена", "Хорошо)");
            //  };
        }
        /// <summary>
        /// Сумма операции
        /// </summary>
        public int Value { get => int.Parse(txtValue.Text); set => txtValue.Text = value.ToString(); }
        /// <summary>
        /// категория 
        /// </summary>
        public string Category { get => txtCategory.Text; set => txtCategory.Text=value; }
        /// <summary>
        /// коментарий
        /// </summary>
        public string Details { get => txtDetails.Text; set =>txtDetails.Text=value; }
        /// <summary>
        /// сторка котрая будет изменяться
        /// </summary>
        public Stroka theStroka { get; set; }

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void BtnSaveChanges_Clicked(object sender, EventArgs e)
        {
            provider.Action(sender, e);
            await DisplayAlert("Изменения", "Запись сохранена", "Хорошо)");
            await Navigation.PopAsync();
        }
    }
}
