using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourFoodApp3
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPreloadedRecipeAsync();
        }

        private async void OnBookmarkTapped(object sender, EventArgs e)
        {
            Label tappedLabel = (Label)sender;
            PreloadedRecipe item = tappedLabel.BindingContext as PreloadedRecipe;

            if (item.Bookmark == "yes")
            {                                
                int rowId = item.Id;
                await App.Database.UpdateBookmark(rowId, "no");
                await DisplayAlert("Alert", "Removed from bookmark!", "OK");
            }
            else
            {               
                int rowId = item.Id;
                await App.Database.UpdateBookmark(rowId, "yes");
                await DisplayAlert("Alert", "Bookmarked!", "OK");
            }
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PreloadedRecipe recipe = (PreloadedRecipe)e.CurrentSelection.FirstOrDefault();

            if (recipe != null) 
            {
                Navigation.PushAsync(new RecipeDetails(recipe));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
