using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    public partial class App : Application
    {
        private static Database database;

        public static List<PreloadedRecipe> preloadedRecipe { get; set; }

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
            //var tofu = File.ReadAllBytes("tofu.png");

            preloadedRecipe = new List<PreloadedRecipe>();

            preloadedRecipe.Add(new PreloadedRecipe { Id = 1, RecipeName = "Mushroom & Tofu Stir-Fry", Description = "Quick and easy, making it a great go-to weeknight meal.", Time = "20 mins", Ingredients = "\u2022 1 bunch scallions, trimmed and cut into 2-inch pieces\r\n\r\n\u2022 1 tablespoon grated fresh ginger\r\n\r\n\u2022 1 large clove garlic, grated\r\n\r\n\u2022 1 (8 ounce) container baked tofu or smoked tofu, diced\r\n\r\n\u2022 3 tablespoons oyster sauce or vegetarian oyster sauce", Steps = "1) Heat 2 tablespoons oil in a large flat-bottom wok or cast-iron skillet over high heat.\r\n\r\n 2) Add mushrooms and bell pepper; cook, stirring occasionally, until soft, about 4 minutes.\r\n\r\n 3) Stir in scallions, ginger and garlic; cook for 30 seconds more.\r\n\r\n 4) Transfer the vegetables to a bowl.", Bookmark = "No", Image = "tofu.png" });
            preloadedRecipe.Add(new PreloadedRecipe { Id = 2, RecipeName = "Balsamic-Parmesan Sautéed Spinach", Description = "Quick and flavorful side dish.", Time = "15 mins", Ingredients = "• 2 tablespoons extra-virgin olive oil\r\n\r\n• 3 cloves garlic, minced\r\n\r\n• 1 pound fresh spinach\r\n\r\n• ¼ teaspoon salt\r\n\r\n• ¼ teaspoon ground pepper\r\n\r\n• 2 tablespoons grated Parmesan cheese\r\n\r\n• 4 teaspoons good-quality balsamic vinegar or balsamic glaze", Steps = "1) Heat oil in a large pot over medium heat.\r\n\r\n 2) Add garlic and cook, stirring, until fragrant, 30 seconds to 1 minute.\r\n\r\n 3) Add spinach, salt and pepper; toss to coat.\r\n\r\n 4) Cook, stirring, until just wilted, 3 to 5 minutes.\r\n\r\n 5) Remove from heat and stir in Parmesan.\r\n\r\n 6) Drizzle with vinegar (or glaze) and serve immediately.", Bookmark = "No", Image = "spinach.png"});
            preloadedRecipe.Add(new PreloadedRecipe { Id = 3, RecipeName = "Skillet Steak with Mushroom Sauce", Description = "Steak, broccolini and pea dinner is a one-skillet meal", Time = "25 mins", Ingredients = "• 12 ounces boneless beef top sirloin steak, cut 1 inch thick and trimmed\r\n\r\n• 2 teaspoons salt-free steak grilling seasoning.\r\n\r\n• 2 cloves garlic, minced\r\n\r\n• ½ teaspoon salt, divided\r\n\r\n• 2 teaspoons canola oil\r\n\r\n• 6 ounces broccolini, trimmed\r\n\r\n• 2 cups frozen peas\r\n\r\n• 1 teaspoon chopped fresh thyme\r\n\r\n3 cups sliced fresh mushrooms\r\n\r\n1 cup unsalted beef broth\r\n\r\n1 tablespoon whole-grain mustard\r\n\r\n• 2 teaspoons cornstarch", Steps = "1) Preheat oven to 350°F.\r\n\r\n 2) Sprinkle steak with steak seasoning, garlic and 1/4 teaspoon salt.\r\n\r\n 3) Heat oil in a 12-inch cast-iron skillet over medium-high heat.\r\n\r\n 4) Add the steak and broccolini. Cook for 4 minutes, turning the broccolini once (do not turn the steak).\r\n\r\n 5) Place peas around the steak; sprinkle with thyme.\r\n\r\n 6) Transfer the skillet to oven and bake until the steak is medium-rare (145°F), about 8 minutes.\r\n\r\n 7) Transfer the steak and vegetables to a plate (leave the drippings in the pan); cover and keep warm.\r\n\r\n 8) Add mushrooms to the drippings in the pan.\r\n\r\n 9) Cook over medium-high heat for 3 minutes, stirring occasionally.\r\n\r\n 10) Whisk broth, mustard, cornstarch and the remaining ¼ teaspoon salt in a small bowl or measuring cup; add to the pan with the mushrooms.\r\n\r\n 11) Cook, stirring, until thick and bubbly, about 1 to 2 minutes.\r\n\r\n 12) Cook, stirring, for 1 minute more.\r\n\r\n 13) Serve the steak and vegetables with the sauce.", Bookmark = "No", Image = "spinach.png" });
            preloadedRecipe.Add(new PreloadedRecipe { Id = 4, RecipeName = "Eggplant & Chickpea Baked Pasta", Description = "Comforting vegetarian baked-pasta dish.", Time = "50 mins", Ingredients = "• 8 ounces whole-wheat fusilli\r\n\r\n• ½ cup coarse dry whole-wheat breadcrumbs (see Note)\r\n\r\n• 1 tablespoon extra-virgin olive oil\r\n\r\n• 3 cup Eggplant & Chickpea Stew (see associated recipe)\r\n\r\n• 1 cup crumbled feta cheese\r\n\r\n• ½ cup chopped fresh mint or basil, divided\r\n\r\n• 2 tablespoons lemon juice", Steps = "1) Preheat oven to 350 degrees F.\r\n\r\n 2) Coat an 8-inch-square (or similar 2-quart) baking dish with cooking spray.\r\n\r\n 3) Bring a large pot of water to a boil.\r\n\r\n 4) Cook pasta according to package directions. Drain and rinse.\r\n\r\n 5) Combine breadcrumbs and oil in a small bowl.\r\n\r\n 6) Toss the pasta with stew, feta, 1/4 cup mint (or basil) and lemon juice in a large bowl.\r\n\r\n 7) Spread the mixture in the prepared baking dish. Top with the breadcrumb mixture.\r\n\r\n 8) Bake until the topping is golden and crispy, about 30 minutes. Sprinkle with the remaining 1/4 cup mint (or basil). ", Bookmark = "No", Image = "spinach.png" });
            preloadedRecipe.Add(new PreloadedRecipe { Id = 5, RecipeName = "Balsamic-Parmesan Sautéed Spinach", Description = "Quick and flavorful side dish.", Time = "15 mins", Ingredients = "test", Steps = "test", Bookmark = "No", Image = "spinach.png" });

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
