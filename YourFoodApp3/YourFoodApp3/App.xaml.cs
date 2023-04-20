﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    public partial class App : Application
    {
        private static Database database;

        public static List<PreloadedRecipe> preloadedRecipe { get; set; }

        private readonly SQLiteAsyncConnection _conn;

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


            //insert preloaded recipes into preloadedrecipe table - do it once only
            preloadedRecipe = new List<PreloadedRecipe>();

            preloadedRecipe.Add(new PreloadedRecipe { Id = 1, RecipeName = "Mushroom & Tofu Stir-Fry", Description = "Quick and easy, making it a great go-to weeknight meal.", Time = "20 mins", Ingredients = "test", Steps = "test", Bookmark = "No", Image = "tofu.png"});
            preloadedRecipe.Add(new PreloadedRecipe { Id = 2, RecipeName = "Balsamic-Parmesan Sautéed Spinach", Description = "Quick and flavorful side dish.", Time = "15 mins", Ingredients = "test", Steps = "test", Bookmark = "No", Image = "spinach.png"});

            foreach (var recipe in preloadedRecipe)
            {
                Database._database.InsertAsync(recipe);
            }

            //navigate to main page
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
