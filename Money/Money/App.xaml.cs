﻿using System;
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
        /// Доступ к записям
        /// </summary>
        static StringDB database;

        /// <summary>
        /// Список значений  для прибыли
        /// </summary>
        static TypePlusDB plusDB;
        /// <summary>
        /// Список значений для расходов
        /// </summary>
        static TypeMinusDb minusDB;

        /// <summary>
        /// Список строк для заполнения доход
        /// </summary>
        public static List<string> plusList { get; set; }
        /// <summary>
        /// Срисок строк для заполнения строк расход
        /// </summary>
        public static List<string> minusList { get; set; }

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

        public static TypePlusDB PlusDB
        {
            get
            {
                if (plusDB == null)
                {
                    plusDB = new TypePlusDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pluses.db3"));
                   
                }
                return plusDB;
            }
        }

        public static TypeMinusDb MinusDB
        {
            get
            {
                if (minusDB == null)
                {
                    minusDB = new TypeMinusDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "minuses.db3"));                    
                }
                return minusDB;
            }
        }

        public App()
        {
            InitializeComponent();

            var arr1 = PlusDB.GetStringAsync().Result.Select(r => new { str = r.Value });
            plusList = new List<string>();
            foreach (var e in arr1)
            {
                plusList.Add(e.str);
            }

            var arr2 = MinusDB.GetStringAsync().Result.Select(r => new {str = r.Value});
            minusList = new List<string>();
            foreach (var e in arr2)
            {
                minusList.Add(e.str);
            }

            MainPage = new MainPage();
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
    }

    
}
