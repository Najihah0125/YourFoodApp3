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

        private void OnBookmarkTapped(object sender, EventArgs e)
        {
            Label tappedBookmark = (Label)sender;

            //FontFamily fontFamily = bookmark.FontFamily;

            //if(tappedBookmark.FontFamily == (OnPlatform<string>)Application.Current.Resources["FASolid"]){
            //    tappedBookmark.FontFamily = originalFont;
            //}else
            //{
            //    originalFont = tappedBookmark.FontFamily;
            //    tappedBookmark.FontFamily = (OnPlatform<string>)Application.Current.Resources["FASolid"];
            //}
            
            //Label tappedLabel = (Label)sender;
            //tappedLabel.FontFamily = (Xamarin.Forms.OnPlatform<string>)Application.Current.Resources["FASolid"];
        }
    }
}
