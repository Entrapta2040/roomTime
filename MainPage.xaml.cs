using roomTime.Platforms;
using Microsoft.Maui.Controls;

namespace roomTime
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToCreatePL(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlanLekcjiPage());
        }
        private async void GoToEditPL(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPlanLekcjiPage());
        }
    }
}
