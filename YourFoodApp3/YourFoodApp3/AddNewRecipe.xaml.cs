using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewRecipe : ContentPage
    {
        public AddNewRecipe()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var added = App.Database.GetAddedRecipeAsync().Result;
            if (added == null || added.Count == 0) 
            {
                AddedRecipeLabel.Text = "No recipe added yet";
                collectionView.IsVisible = false;
            } 
            else
            {
                AddedRecipeLabel.IsVisible = false;
            }
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAddedRecipeAsync();  
        }

        async void OnPlusClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeForm());
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddedRecipe addedrecipe = (AddedRecipe)e.CurrentSelection.FirstOrDefault();

            if (addedrecipe != null)
            {
                Navigation.PushAsync(new AddedRecipeDetails(addedrecipe));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}