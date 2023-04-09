using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeForm : ContentPage
    {
        public RecipeForm()
        {
            InitializeComponent();
        }

        async void OnSubmitClick(object sender, EventArgs e)
        {
            await App.Database.AddRecipeAsync(new AddedRecipe
            {
                RecipeName = inputRecipeName.Text,
                Description = inputDescription.Text,
                Time = inputTime.Text,
                Ingredients = inputIngredients.Text,
                Steps= inputSteps.Text,

                
        });
            await Navigation.PushAsync(new AddNewRecipe());
        }
    }
}