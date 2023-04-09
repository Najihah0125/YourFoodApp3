using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    public partial class App : Application
    {
        private static Database database;

        public static Database Database
        {
            get
            {
                //create database in phone
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "yourfood.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MasterDetailPageYourFood();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
