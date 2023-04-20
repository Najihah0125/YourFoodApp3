using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeForm : ContentPage
    {
        string imagePath;
        public RecipeForm()
        {
            InitializeComponent();
        }

        async void OnButtonClick(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick an image"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
                imagePath = result.FullPath;
            }
            
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
                Image = imagePath,
                
        });
            await Navigation.PushAsync(new AddNewRecipe());
        }
    }
}