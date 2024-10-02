using roomTime;

namespace roomTime.Platforms;

public partial class CreatePlanLekcjiPage : ContentPage
{
	public CreatePlanLekcjiPage()
	{
		InitializeComponent();
    }

    private async void GoToPhotoPL(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReadPhotoPage());
    }
    private async void GoToFormPL(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateFormPage());
    }
}