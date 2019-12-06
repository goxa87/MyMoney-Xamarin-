using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Money.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public partial class App : Application
    {
        /// <summary>
        /// Записная книжка
        /// </summary>
        //public static MoneyModelLibrary.MoneyBook book { get; set;}


        static StringDB database;

        public static StringDB Database
        {
            get {
                if (database == null)
                {
                    database = new StringDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Strokas.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //book = new MoneyBook("Goxa");
            //book.Book[0].Data = DateTime.Today.AddDays(-2);
            //book.Book[1].Data = DateTime.Today.AddDays(-2);
            //book.Book[2].Data = DateTime.Today.AddDays(-2);
            //recordType = new RecordType(Exception);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /// <summary>
        /// Заглушка для создания объекта recordType
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        public static void Exception(string s, int i)
        {
        }

    }

    
}
