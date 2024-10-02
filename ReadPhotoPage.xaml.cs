using Microsoft.Maui.Controls;

namespace roomTime
{
    public partial class ReadPhotoPage : ContentPage
    {
        public ReadPhotoPage()
        {
            InitializeComponent();
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}