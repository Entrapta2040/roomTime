using Microsoft.Maui.Controls;

namespace roomTime
{
    public partial class CreateFormPage : ContentPage
    {
        public CreateFormPage()
        {
            InitializeComponent(); // Ensure this exists
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
