using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Money
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            BarBackgroundColor = Color.FromHex("#EFF3DB");
            BarTextColor = Color.Black;
            SelectedTabColor = Color.Gold;
            //UnselectedTabColor = Color.White;

            var addString = new AddString();
            addString.Title = "ДОБАВИТЬ";
            addString.IconImageSource = "homeImg.png";
            var selection = new NavigationPage(new Selection()) { Title = "ПОИСК" , BarBackgroundColor = Color.FromHex("#EFF3DB"), BarTextColor = Color.Black};
            var reportPage = new Report() { Title = "ОТЧЕТ" };
            Children.Add(addString);
            Children.Add(selection); // навигация
            Children.Add(reportPage);
        }
    }
}