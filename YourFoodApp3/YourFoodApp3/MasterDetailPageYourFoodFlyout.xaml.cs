using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourFoodApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageYourFoodFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageYourFoodFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageYourFoodFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MasterDetailPageYourFoodFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageYourFoodFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageYourFoodFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageYourFoodFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageYourFoodFlyoutMenuItem { Id = 0, Title = "Recipes", TargetType=typeof(MainPage)  },
                    new MasterDetailPageYourFoodFlyoutMenuItem { Id = 1, Title = "Bookmark", TargetType=typeof(Bookmark) },
                    new MasterDetailPageYourFoodFlyoutMenuItem { Id = 2, Title = "Add New Recipe", TargetType=typeof(AddNewRecipe) },
                    new MasterDetailPageYourFoodFlyoutMenuItem { Id = 3, Title = "About", TargetType=typeof(About) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}