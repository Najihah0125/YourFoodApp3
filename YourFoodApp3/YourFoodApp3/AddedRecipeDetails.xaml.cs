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
    public partial class AddedRecipeDetails : ContentPage
    {
        public AddedRecipeDetails(AddedRecipe recipe)
        {
            InitializeComponent();
            BindingContext = recipe;
        }

        async void OnDeleteClick (object sender, EventArgs e)
        {
            var item = (AddedRecipe)BindingContext;
            await App.Database.DeleteRecipe(item);
            await Navigation.PushAsync(new AddNewRecipe());
        }

        async void OnEditClick(object sender, EventArgs e)
        {
            var item = (AddedRecipe)BindingContext;
            
            await Navigation.PushAsync(new RecipeForm(item));           
        }
    }
}