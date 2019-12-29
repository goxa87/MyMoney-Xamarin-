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
            SelectedTabColor = Color.Red;
            //UnselectedTabColor = Color.White;
            

            var addString = new AddString();
            addString.Title = "ДОБАВИТЬ";
            addString.IconImageSource = "ico2.png";


            var selection = new NavigationPage(new Selection()) { Title = "ПОИСК" , BarBackgroundColor = Color.FromHex("#EFF3DB"), BarTextColor = Color.Black};
            selection.IconImageSource = "ico3.png";

            var reportPage = new NavigationPage( new Report()) { Title = "ОТЧЕТ", BarBackgroundColor = Color.FromHex("#EFF3DB"), BarTextColor = Color.Black };
            reportPage.IconImageSource = "ico4.png";

            var propPage = new NavigationPage(new Properties()) { Title = "Настройки", BarBackgroundColor = Color.FromHex("#EFF3DB"), BarTextColor = Color.Black };
            propPage.IconImageSource = "ico5.png";
            Children.Add(addString);
            Children.Add(selection); // навигация
            Children.Add(reportPage);
            Children.Add(propPage);

            
        }
                
    }
}