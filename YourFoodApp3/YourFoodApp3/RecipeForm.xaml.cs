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

        AddedRecipe _addedRecipe;
        public RecipeForm(AddedRecipe item)
        {
            InitializeComponent();
            _addedRecipe = item;
            Title = "Edit Recipe";
            inputRecipeName.Text = item.RecipeName;
            inputDescription.Text = item.Description;
            inputTime.Text = item.Time;
            inputIngredients.Text = item.Ingredients;
            inputSteps.Text = item.Steps;
            imagePath = item.Image;

            resultImage.Source = imagePath;

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
            if (_addedRecipe != null)
            {
                EditRecipe();
            } 
            else
            {
                await App.Database.AddRecipeAsync(new AddedRecipe
                {
                    RecipeName = inputRecipeName.Text,
                    Description = inputDescription.Text,
                    Time = inputTime.Text,
                    Ingredients = inputIngredients.Text,
                    Steps = inputSteps.Text,
                    Image = imagePath,
                });
                await Navigation.PushAsync(new AddNewRecipe());
            }                        
        }

        async void EditRecipe()
        {
            _addedRecipe.RecipeName = inputRecipeName.Text;
            _addedRecipe.Description = inputDescription.Text;
            _addedRecipe.Time = inputTime.Text;
            _addedRecipe.Image = imagePath;
            _addedRecipe.Ingredients = inputIngredients.Text;
            _addedRecipe.Steps = inputSteps.Text;

            await App.Database.UpdateAddedRecipe(_addedRecipe);
            await Navigation.PushAsync(new AddNewRecipe());
        }
    }
}