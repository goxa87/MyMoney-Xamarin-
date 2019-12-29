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
            BarBackgroundColor = Color.FromHex("#1b5972");
            BarTextColor = Color.FromHex("#ffcd00");
            SelectedTabColor = Color.Gold;
            UnselectedTabColor = Color.White;


            var addString = new NavigationPage(new AddString() {Title= "Добавить запись" });
            addString.Title = "ДОБАВИТЬ";
            addString.IconImageSource = "ico2.png";


            var selection = new NavigationPage(new Selection()) { Title = "ПОИСК" };
            selection.IconImageSource = "ico3.png";

            var reportPage = new NavigationPage( new Report()) { Title = "ОТЧЕТ"};
            reportPage.IconImageSource = "ico4.png";

            var propPage = new NavigationPage(new Properties()) { Title = "Настройки"};
            propPage.IconImageSource = "ico5.png";
            Children.Add(addString);
            Children.Add(selection); // навигация
            Children.Add(reportPage);
            Children.Add(propPage);

            
        }
                
    }
}