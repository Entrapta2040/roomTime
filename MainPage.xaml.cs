using roomTime;
using Microsoft.Maui.Controls;

namespace roomTime
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToFormPL(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateFormPage());
        }
        private async void GoToEditPL(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPlanLekcjiPage());
        }
    }
}
