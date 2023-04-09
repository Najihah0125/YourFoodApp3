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
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAddedRecipeAsync();  
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeForm());
        }
    }
}