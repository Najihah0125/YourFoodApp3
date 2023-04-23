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
    public partial class Bookmark : ContentPage
    {
        public Bookmark()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var bookmark = App.Database.GetBookmarkedRecipeAsync().Result;
            if (bookmark == null || bookmark.Count == 0)
            {
                BookmarkLabel.Text = "Bookmark Empty";
                collectionView.IsVisible = false;
            }
            else
            {
                BookmarkLabel.IsVisible = false;
            }
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetBookmarkedRecipeAsync();
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

        private async void OnTrashTapped(object sender, EventArgs e)
        {
            Label tappedLabel = (Label)sender;
            PreloadedRecipe item = tappedLabel.BindingContext as PreloadedRecipe;

            int rowId = item.Id;
            await App.Database.UpdateBookmark(rowId, "no");
            await DisplayAlert("Alert", "Removed from bookmark!", "OK");                       
        }
    }
}