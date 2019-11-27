using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MoneyModelLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage
    {
        ObservableCollection<Stroka> List { get; }
        public ListView(ObservableCollection<Stroka> list)
        {
            InitializeComponent();
            List = list;
            //if (List.Count == 0 || List == null)
                //lblN.Text = "лист = 0 или пуст";
            lvViborka.ItemsSource = List;
        }

    }
}
